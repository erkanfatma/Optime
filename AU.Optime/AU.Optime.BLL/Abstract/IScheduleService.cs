using AU.Optime.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AU.Optime.Entities.ComplexTypes;

namespace AU.Optime.BLL.Abstract {
      //To specify operations that connect different layers
      public interface IScheduleService {
            //to get daily schedule list depend on user
            List<ScheduleModel> GetDaily(int? userId);
            //to get weekly schedule list depend on user
            List<ScheduleModel> GetWeekly(int? userId);
            //to get monthly schedule list depend on user
            List<ScheduleModel> GetMonthly(int? userId);
            //to get all schedule by user
            List<ScheduleModel> GetAllByUserId(int? userId);
            //to delay tasks from schedule list
            void UpdateScheduleModel(ScheduleModel model);
      }
}
