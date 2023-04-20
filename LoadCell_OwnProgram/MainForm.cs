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
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
//CARSONNNNSSS current working code
namespace LoadCell_OwnProgram
{
    public partial class MainForm : Form
    {
        // Create a new instance (variable) of the TestingClass within MainForm
        TestingClass testingClass = new TestingClass();
        private System.Windows.Forms.Timer pictureTimer;
        private int currentPictureIndex = 0;
        private CameraClass camera = new CameraClass();
        private Bitmap myImage;
        //Initialize Button. Moves grip to home position and runs "Initialize" thread from testing.cs
        private void InitializeButton_Click(object sender, EventArgs e)
        {
            InitializeButton.Enabled = false; //Disable initialization button
            StartButton.Enabled = true; //Enable start button
            testingClass.Initialize();  //Calls on Initialize function from TestingClass
            Task updateGuiTask = Task.Run(() => updateGui());
        }

        //Start Button. Runs RunningTest and StoringData from TestingClass.cs
        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = false; // Disable the start button
            testingClass.Preload(); //idea is to not run a task so that preload has to run till completion before the next two tasks can start running
            // Create two separate tasks to run StoringData and RunningTest from TestingClass.cs
            Task storingDataTask = Task.Run(() => testingClass.StoringData());
            Task runningTestTask = Task.Run(() => testingClass.RunningTest());
        }

        //Stop Button.
        private void StopButton_Click(object sender, EventArgs e)
        {
            Task stoppingDataTask = Task.Run(() => testingClass.StoppingTest()); // Runs StoppingTest() from TestingClass.cs

            //closes GUI - do we really want the GUI to close when you press stop? 
            this.Close();
            Application.Exit();
        }
//----------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Function that updates GUI while test is running
        public void updateGui()
        {
            var timer = new System.Threading.Timer(  //Timer rather than a loop bc a loop screws with load cell
                callback: (_) => //Method that runs when the timer ticks
                {
                    // update the ForceLabel, StressLabel, TimeLabel, DispOutput, and 4 Temperatures on the main thread
                    this.Invoke((MethodInvoker)delegate {
                        ForceLabel.Text = TestingClass.force.ToString();
                    });
                    this.Invoke((MethodInvoker)delegate {
                        StressLabel.Text = TestingClass.stress.ToString();
                    });
                    this.Invoke((MethodInvoker)delegate {
                        TimeLabel.Text = TestingClass.timeElapsed.ToString();
                    });
                    this.Invoke((MethodInvoker)delegate {
                        DispLabel.Text = TestingClass.displacement.ToString();
                    });
                    this.Invoke((MethodInvoker)delegate {
                        Temp1Label.Text = testingClass.thermocoupleData.getCurrentTC1Temp().ToString();
                    });
                    this.Invoke((MethodInvoker)delegate {
                        Temp2Label.Text = testingClass.thermocoupleData.getCurrentTC2Temp().ToString();
                    });
                    this.Invoke((MethodInvoker)delegate {
                        Temp3Label.Text = testingClass.thermocoupleData.getCurrentTC3Temp().ToString();
                    });
                    this.Invoke((MethodInvoker)delegate {
                        Temp4Label.Text = testingClass.thermocoupleData.getCurrentTC4Temp().ToString();
                    });

                    //Update chart every time timer ticks
                    this.Invoke((MethodInvoker)delegate {
                        UpdateChart(TestingClass.displacement, TestingClass.force, TestingClass.stress);
                    });
                    this.Invoke((MethodInvoker)delegate
                    {
                        updatePicture();
                    });
                },
                state: null,//timer stuff
                dueTime: 0,//amount of time delay before the timer initially starts
                period: 100);//interval between timer ticks
            var stopped = new ManualResetEvent(false); // Wait for the timer to stop before returning. This will keep the StoringData method running until the timer is stopped
            stopped.WaitOne(); //wait for event to be signaled
            timer.Dispose(); // Dispose the timer to free up resources
        }

        public void UpdateChart(double displacement, double force, double stress) //Creating and updating chart in GUI
        {
            this.Invoke((MethodInvoker)delegate {
                // Update chart series data on the main UI thread
                ForceChart.Series["Force vs Displacement"].Points.AddXY(displacement, force);
            });
            this.Invoke((MethodInvoker)delegate {
                // Update chart series data on the main UI thread
                StressChart.Series["Stress vs Displacement"].Points.AddXY(displacement, stress);
            });
        }
        public void updatePicture()
        {
            //Thread.Sleep(10000);
            List<String> filenames = camera.returnList();
            for(int i = 0; i < filenames.Count; i++)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                myImage = new Bitmap(filenames[i]);
                pictureBox1.Image = (Image) myImage;
            }
        }
        //private void StartUpdatingPictureBox()
        //{
        //    // Initialize the timer to fire every 5 seconds
        //    pictureTimer = new System.Windows.Forms.Timer();
        //    pictureTimer.Interval = 10000;
        //    pictureTimer.Tick += PictureTimer_Tick;
        //    pictureTimer.Start();

        //    // Update the picture box with the first image
        //    UpdatePictureBox();
        //}

        //private void PictureTimer_Tick(object sender, EventArgs e)
        //{
        //    // Update the picture box with the next image
        //    currentPictureIndex++;
        //    UpdatePictureBox();
        //}

        //private void UpdatePictureBox()
        //{
        //    // Construct the file name for the current picture
        //    string fileName = $"Accquisition C-Sharp-{currentPictureIndex}.jpg";

        //    // Check if the file exists
        //    if (File.Exists(fileName))
        //    {
        //        // Load the image from the file
        //        Image image = Image.FromFile(fileName);

        //        // Display the image in the picture box
        //        pictureBox1.Image = image;
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------------------------------
        //Default geometries, strainrate, and acquisiton rate. These values only change if user enters something new
        public static decimal length = 5;
        public static decimal width = 1;
        public static decimal thick = 1;
        public static decimal strainrate = .001m; // default is 10^-3 [1/s]
        public static decimal acq_rate = 0.5m; //default acquisiton rate set to 0.5 Hz
        public static decimal max_strain = 0.5m;
        public static double preload = 1.0;
        public static string tc_com = "COM9"; //default com port. to change default change this, and can change text box properties to make visual default align with this
        public static string act_com = "COM10"; //default actuator port

        //Functions that change the value of the variables only if the user inputs new values in the GUI
        public void numericUpDown1_ValueChanged(object sender, EventArgs e)//taking user input to determine gauge length
        {
            length = (decimal)numericUpDown1.Value;
        }
        public void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            width = (decimal)numericUpDown2.Value;
        }
        public void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            thick = (decimal)numericUpDown3.Value;
        }
        public void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            strainrate = (decimal)numericUpDown4.Value;
        }
        public void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            acq_rate = (decimal)numericUpDown5.Value;
        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            max_strain = (decimal)numericUpDown6.Value;
        }
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            preload = (double)numericUpDown7.Value;
        }
        public void textBox1_TextChanged(object sender, EventArgs e) //TC Com Port
        {
            tc_com = (string)textBox1.Text;
        }
        public void textBox2_TextChanged(object sender, EventArgs e) //Actuator Com Port
        {
            act_com= (string)textBox2.Text;
        }
//--------------------------------------------------------------------------------------------------------------------------------

        //trying to make the .csv file able to be renamed / relocated
        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "CSV file (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                // Save the file with the chosen file name and location
            }

        }
        //Opening the window and loading the MainForm
        public MainForm() //This is the function that runs as soon as you press run
        {
            InitializeComponent();
            // Add chart title and axis labels
            ForceChart.Titles.Add("Force vs Displacement");
            ForceChart.ChartAreas[0].AxisX.Title = "Displacement [um]";
            ForceChart.ChartAreas[0].AxisY.Title = "Force [N]";
            StressChart.Titles.Add("Stress vs Displacement");
            StressChart.ChartAreas[0].AxisX.Title = "Displacement [um]";
            StressChart.ChartAreas[0].AxisY.Title = "Stress [MPa]";
        }
        private void MainForm_Load(object sender, EventArgs e) 
        {
        }
    }
}
