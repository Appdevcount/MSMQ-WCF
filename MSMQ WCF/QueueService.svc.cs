using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MSMQ_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    //public class QueueService : IQueueTransactService 
    //{
        
    //    [OperationBehavior(TransactionScopeRequired =true)]
    //    public void GetDataT(string value)
    //    {
    //        //if (value == "Bad")

    //        //{

    //        //    throw new InvalidOperationException("Bad!");

    //        //}
    //        //throw new NotImplementedException();
    //    }

    //    //public void GetDataUsingDataContract(CompositeType composite)
    //    //{
    //    //    if (composite == null)
    //    //    {
    //    //        throw new ArgumentNullException("composite");
    //    //    }
    //    //    if (composite.BoolValue)
    //    //    {
    //    //        composite.StringValue += "Suffix";
    //    //    }
    //    //    //return composite;
    //    //}
    //}
    public class QueueService : IQueueNonTransactService
    {

        public void GetData(int value)
        {

            //System.Diagnostics.Trace.Write(string.Format("You entered: {0}", value));//Causes to debug w3wp.exe so commented. Also I started the MSMQClient app in admistrator mode, for any possible permission issues
            //return string.Format("You entered: {0}", value);
        }

        
        //public void GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    //return composite;
        //}
    }

}
