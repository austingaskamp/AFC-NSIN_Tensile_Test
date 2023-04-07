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
using System.Threading.Tasks; //multiple tasks can run simulataneously
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
         //change this based on what computer you're using - port that thermocouples are connected to
        private CameraClass camera = new CameraClass();
        
        //Called upon whenever the initialize button is pressed. Connects to actuator, tells it to move to home position, begins load cell data acq and prompts user to load sample. 
        public void Initialize()
        {
            thermocoupleData = new ThermoClass(MainForm.tc_com);

            using (var connection = Zaber.Motion.Ascii.Connection.OpenSerialPort(MainForm.act_com)) //change this based on what computer you're using - port that your controller is connected to 
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

        public DateTime FirstExportTime { get; private set; } //Making it a global variable so StoringData() can ref it
        public TimeSpan timeSinceFirstExport; //Making it a global variable so MainForm and StoringData() can reference it 
        //Called upon whenever the start button is pressed. 
        public void RunningTest()
        {
            FirstExportTime = DateTime.Now;//Timer starts when button is pressed
            Task actuatorTask = Task.Run(() => actuator.LinearActuator(ref displacement));
            Task cameraTask = Task.Run(() => camera.MainMethodRun());
        }


        public static int displacement; //defining private field to store value of displacement for ActuatorClass
        public static double force; //defining private field to store value of force for LoadCellClass
        public static double stress; //defining private field to store value of stress for LoadCellClass
        public static double timeElapsed;

        public void StoringData()
        {
            var timer = new System.Threading.Timer(  //timer rather than a loop bc a loop screws with load cell
                callback: (_) => //method that runs when the timer ticks
                {
                    timeSinceFirstExport = (DateTime.Now - FirstExportTime);//total time elapsed since first data point
                    timeElapsed = timeSinceFirstExport.TotalSeconds;
                    Console.WriteLine("this is running");
                    List<float> temp = thermocoupleData.recordCurrentTemps();//tc stuff
                    var data = new double[] { timeElapsed, displacement, force, stress, temp[0], temp[1], temp[2], temp[3] }; //create an array of doubles
                    dataList.Add(data); //adding array to list of arrays (dataList)
                },
                state: null,//timer stuff
                dueTime: 0,//amount of time delay before the timer initially starts
                period: Convert.ToInt32(1000 / MainForm.acq_rate));//interval between timer ticks. this converts acq_rate from Hz to ms between ticks
            var stopped = new ManualResetEvent(false); // Wait for the timer to stop before returning. This will keep the StoringData method running until the timer is stopped
            stopped.WaitOne(); //wait for event to be signaled
            timer.Dispose(); // Dispose the timer to free up resources
        }

        //Called upon whenever the stop button is pressed. Exports array to .csv.
        public void StoppingTest()
        {
            string path = "test_data.csv"; //file location for where to save the data
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
            thermocoupleData.closeComPort();
            Console.WriteLine("The test has been stopped");
        }
    }
}
