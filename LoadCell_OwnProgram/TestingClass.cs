using System;
using System.Windows.Forms;
using System.Threading;
using FUTEK_USB_DLL;
using Zaber.Motion;
using Zaber.Motion.Ascii;
using SpinnakerNET;
using SpinnakerNET.GenApi;
using Spinnaker;
using System.IO;
using System.Collections.Generic;
using Zaber.Motion.Binary;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace LoadCell_OwnProgram
{

    public class TestingClass
    {
        public List<double[]> dataList = new List<double[]>(); //creates a global list of doubles
        public StreamWriter writer; 
        
        //Creating an instance of ActuatorClass, LoadCellClass within TestingClass
        private ActuatorClass actuator = new ActuatorClass();
        private LoadCellClass loadCell = new LoadCellClass();
        public ThermoClass thermocoupleData; 
        private CameraClass camera = new CameraClass();

        public static int displacement; //defining private field to store value of displacement for ActuatorClass
        public static double force; //defining private field to store value of force for LoadCellClass
        public static double stress; //defining private field to store value of stress for LoadCellClass
        public static double timeElapsed;

        public DateTime FirstExportTime { get; private set; } //Making it a global variable so StoringData() can ref it
        public TimeSpan timeSinceFirstExport; //Making it a global variable so MainForm and StoringData() can reference it 


        //Called upon whenever the initialize button is pressed.
        //Connects to actuator, tells it to move to home position, begins load cell data acq and prompts user to load sample. 
        //Establishes connection with Arduino through user-input COM port, Arduino reads in data from thermocuples, converting to readable values
        public void Initialize()
        {
            thermocoupleData = new ThermoClass(MainForm.tc_com);

            //This 'using' function needs to get moved to the actuator class and repackaged as 'initializeActuator'

            using (var connection = Zaber.Motion.Ascii.Connection.OpenSerialPort(MainForm.act_com)) //Serial port changes based on user input through GUI - need to add validation checking for this
            {
                
                connection.EnableAlerts(); //connecting to actuator
                var deviceList = connection.DetectDevices();
                Console.WriteLine($"Found {deviceList.Length} devices.");
                var device = deviceList[0];
                var axis = device.GetAxis(1);
                if (!axis.IsHomed())
                {
                    axis.Home();
                }
                axis.MoveAbsolute(60, Units.Length_Millimetres);
                MessageBox.Show("Grips are now at home position. Load the sample and press Start button when you are ready to begin test.");
            Task loadCellTask = Task.Run(() => loadCell.LoadCell(MainForm.width, MainForm.thick, ref force, ref stress)); //starts load cell DAQ
            }
        }
        public void Preload()
        {
            using (var connection = Zaber.Motion.Ascii.Connection.OpenSerialPort(MainForm.act_com)) //change this based on what computer you're using - port that your controller is connected to 
            {
                connection.EnableAlerts(); //connecting to actuator
                var deviceList = connection.DetectDevices();
                Console.WriteLine($"Found {deviceList.Length} devices.");
                var device = deviceList[0];
                var axis = device.GetAxis(1);
                //see if next 4 lines are actually required - could cause to pull sample all the way to home??
                if (!axis.IsHomed())
                {
                    axis.Home();
                }
                //may need to change this to a timer so that it doesn't screw with the load cell loop
                while (stress < MainForm.preload) //change the 10 to a user input
                {
                    axis.MoveRelative(-1, Units.Length_Micrometres);
                    Thread.Sleep(100);
                }
                Thread.Sleep(5000); //wait 5 seconds before letting the next tasks run
            }
        }

        //Called upon whenever the start button is pressed 
        public void RunningTest()
        {
            FirstExportTime = DateTime.Now;//Timer starts when button is pressed
            Task actuatorTask = Task.Run(() => actuator.LinearActuator(ref displacement));
            Task cameraTask = Task.Run(() => camera.MainMethodRun());
        }

        //Called upon whenever the stop button is pressed
        //Exports data to .csv by writing "dataList" to .csv
        //Closes COM port connection with Arduino
        public void StoppingTest()
        {
            string path = "test_data.csv"; //file location for where to save the data - this should be data/time stamped and auto created
            string delimiter = ","; //delimiter used to separate values in the CSV file
            using (StreamWriter sw = new StreamWriter(path))
            {
                // Write headers to the file
                sw.WriteLine("[s] Time Elapsed" + delimiter + "[um] Displacement" + delimiter + "[N] Force" + delimiter + "[MPa] Stress" + delimiter + "[C] Temp 1" + delimiter + "[C] Temp 2" + delimiter + "[C] Temp 3" + delimiter + "[C] Temp 4");

                // Write data to the file
                foreach (double[] i in dataList)
                {
                    string line = string.Join(delimiter, i);
                    sw.WriteLine(line);
                }
            }

            //Closing COM port connection with Arduino
            thermocoupleData.closeComPort();
        }

        //Timer-based function that allows for data recording at user-defined intervals
        public void StoringData()
        {
            var timer = new System.Threading.Timer(  //Timer used in place of a loop to prevent load cell disfunction
                callback: (_) => //Runs every time the timer clicks
                {
                    timeSinceFirstExport = (DateTime.Now - FirstExportTime);//Total time elapsed since first data point collection
                    timeElapsed = timeSinceFirstExport.TotalSeconds;
                    Console.WriteLine("this is running");
                    List<float> temp = thermocoupleData.recordCurrentTemps(); //Record current thermocuple readings from thermocoupleData object
                    var data = new double[] { timeElapsed, displacement, force, stress, temp[0], temp[1], temp[2], temp[3] }; //Create new line of data for .csv. Each "line" of data is an array the dataList variable
                    dataList.Add(data); //Add new line of data ('data' array) to dataList
                },
                state: null,//timer stuff
                dueTime: 0,//Time delay before the timer initially starts
                period: Convert.ToInt32(1000 / MainForm.acq_rate));//Interval between timer ticks. Converts acq_rate from Hz to ms between ticks. acq_rate is a user-inputted value through the GUI. 
            var stopped = new ManualResetEvent(false); //Wait for the timer to stop before returning. This will keep the StoringData method running until the timer is stopped.
            stopped.WaitOne(); //wait for event to be signaled
            timer.Dispose(); // Dispose the timer to free up resources
        }

        

    }
}
