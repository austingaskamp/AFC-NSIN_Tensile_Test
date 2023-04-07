using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zaber.Motion;

namespace LoadCell_OwnProgram
{
    public class ActuatorClass
    {
        public void LinearActuator(ref int displacement)
        {
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

                //calculating time_delay in order to get desired linear velocity 
                decimal velo = MainForm.length * 1000 * MainForm.strainrate; //this is in um/s
                int increment = -1; //should always be -1. This means grips move 1um at a time. To change velo, change time_delay via changing strain rate from GUI 
                decimal time_delay = 1 / velo * 1000; //converting velo to strain rate time delay [s] and then to [ms]                
                decimal disp_limit = MainForm.max_strain * 1000 * MainForm.length;
                //moving actuator at continuous strain rate
                while (displacement < disp_limit)
                {
                    axis.MoveRelative(increment, Units.Length_Micrometres);//this is where the strain rate is entered
                    displacement += 1; //keeping track of how many um the actuator has moved
                    Thread.Sleep((int)time_delay); //should be 200 to have a strain rate of .001
                }
            }
        }
    }
}
