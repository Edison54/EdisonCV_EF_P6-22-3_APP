using EdisonCV_EF_P6_22_3_APP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
namespace EdisonCV_EF_P6_22_3_APP.ViewModels
{
    public class AskViewModel : BaseViewModel
    {

        public Ask MyAsk { get; set; }

        public AskViewModel()
        {


            MyAsk = new Ask();
            
        }


        public async Task<bool> AddNewASK(

       string pAsk,
       string pAskDetail,
       string pPhoto,
       DateTime pDate)

        {
          
            if (IsBusy) return false;
            IsBusy = true;
            try
            {

                MyAsk.Date = pDate;
                MyAsk.AskDescription = pAsk;
                MyAsk.UserId = GlobalObjects.GlobalUser.UserId; ;
                MyAsk.AskStatusId = 1;
                MyAsk.IsStrike = false;
                MyAsk.ImageUrl = pPhoto;
                MyAsk.AskDetail = pAskDetail;

                
                bool R = await MyAsk.AddAsk();
                return R;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
