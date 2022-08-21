using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class SensorDataViewModel
    {
        public SensorDataViewModel()
        {
            SensorDataDTO = new SensorData();
        }
        public SensorData SensorDataDTO
        {
            get;
            set;
        }
        public decimal ID
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.ID > 0) ? SensorDataDTO.ID : new decimal();
            }
            set
            {
                SensorDataDTO.ID = value;
            }
        }

        public long TS
        {
            get
            {
                return (SensorDataDTO != null) ? SensorDataDTO.TS : new long();
            }
            set
            {
                SensorDataDTO.TS = value;
            }
        }
        public string veh_id
        {
            get
            {
                return (SensorDataDTO != null) ? SensorDataDTO.veh_id : string.Empty;
            }
            set
            {
                SensorDataDTO.veh_id = value;
            }
        }

        public decimal p1
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.p1 > 0) ? SensorDataDTO.p1 : new decimal();
            }
            set
            {
                SensorDataDTO.p1 = value;
            }
        }

        public decimal p2
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.p2 > 0) ? SensorDataDTO.p2 : new decimal();
            }
            set
            {
                SensorDataDTO.p2 = value;
            }
        }

        public decimal p3
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.p3 > 0) ? SensorDataDTO.p3 : new decimal();
            }
            set
            {
                SensorDataDTO.p3 = value;
            }
        }

        public decimal p4
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.p4 > 0) ? SensorDataDTO.p4 : new decimal();
            }
            set
            {
                SensorDataDTO.p4 = value;
            }
        }

        public decimal p5
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.p5 > 0) ? SensorDataDTO.p5 : new decimal();
            }
            set
            {
                SensorDataDTO.p5 = value;
            }
        }

        public decimal p6
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.p6 > 0) ? SensorDataDTO.p6 : new decimal();
            }
            set
            {
                SensorDataDTO.p6 = value;
            }
        }

        public decimal t1
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.t1 > 0) ? SensorDataDTO.t1 : new decimal();
            }
            set
            {
                SensorDataDTO.t1 = value;
            }
        }

        public decimal t2
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.t2 > 0) ? SensorDataDTO.t2 : new decimal();
            }
            set
            {
                SensorDataDTO.t2 = value;
            }
        }

        public decimal t3
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.t3 > 0) ? SensorDataDTO.t3 : new decimal();
            }
            set
            {
                SensorDataDTO.t3 = value;
            }
        }

        public decimal t4
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.t4 > 0) ? SensorDataDTO.t4 : new decimal();
            }
            set
            {
                SensorDataDTO.t4 = value;
            }
        }

        public decimal t5
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.t5 > 0) ? SensorDataDTO.t5 : new decimal();
            }
            set
            {
                SensorDataDTO.t5 = value;
            }
        }

        public decimal t6
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.t6 > 0) ? SensorDataDTO.t6 : new decimal();
            }
            set
            {
                SensorDataDTO.t6 = value;
            }
        }

        public decimal Eng
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.Eng > 0) ? SensorDataDTO.Eng : new decimal();
            }
            set
            {
                SensorDataDTO.Eng = value;
            }
        }

        public decimal Power
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.Power > 0) ? SensorDataDTO.Power : new decimal();
            }
            set
            {
                SensorDataDTO.Power = value;
            }
        }

        public decimal Battery
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.Battery > 0) ? SensorDataDTO.Battery : new decimal();
            }
            set
            {
                SensorDataDTO.Battery = value;
            }
        }

        public decimal Lat
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.Lat > 0) ? SensorDataDTO.Lat : new decimal();
            }
            set
            {
                SensorDataDTO.Lat = value;
            }
        }

        public decimal Lon
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.Lon > 0) ? SensorDataDTO.Lon : new decimal();
            }
            set
            {
                SensorDataDTO.Lon = value;
            }
        }

        public decimal BLE
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.BLE > 0) ? SensorDataDTO.BLE : new decimal();
            }
            set
            {
                SensorDataDTO.BLE = value;
            }
        }

        public decimal Mem
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.Mem > 0) ? SensorDataDTO.Mem : new decimal();
            }
            set
            {
                SensorDataDTO.Mem = value;
            }
        }

        public decimal X_axis
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.X_axis > 0) ? SensorDataDTO.X_axis : new decimal();
            }
            set
            {
                SensorDataDTO.X_axis = value;
            }
        }
        public decimal Y_axis
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.Y_axis > 0) ? SensorDataDTO.Y_axis : new decimal();
            }
            set
            {
                SensorDataDTO.Y_axis = value;
            }
        }
        public decimal Z_axis
        {
            get
            {
                return (SensorDataDTO != null && SensorDataDTO.Z_axis > 0) ? SensorDataDTO.Z_axis : new decimal();
            }
            set
            {
                SensorDataDTO.Z_axis = value;
            }
        }


    }
}
