using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MSMQ_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]

    //Non Transactional Queue based MSMQ WCF service
    public interface IQueueNonTransactService
    {

        [OperationContract(IsOneWay = true)] //Operations marked with IsOneWay=true must not declare output parameters, by-reference parameters or return values.It must be void
        void GetData(int value);

        //[OperationContract(IsOneWay = true)]
        //void GetDataUsingDataContract(CompositeType composite);

        //When tried to access the .svc file from IIS got the below error [Queue was not manually created at that time in MSMQ] - Created the queue and accessed teh service from IIS , it resolved the error. The Queue address in address will automatically find the quee and work with that(Incoming/Journal) 
        //An error occurred while opening the queue:The queue does not exist or you do not have sufficient permissions to perform the operation. (-1072824317, 0xc00e0003). 
        //The message cannot be sent or received from the queue.
        //Ensure that MSMQ is installed and running.Also ensure that the queue is available to open with the required access mode and authorization.

        //After Queue created manually got the below error - Select the user from created Queue properties and allow full permission for this queue , it resolved the error
        //An error occurred while opening the queue:Access is denied. (-1072824283, 0xc00e0025). 
        //The message cannot be sent or received from the queue.Ensure that MSMQ is installed and running.
        //Also ensure that the queue is available to open with the required access mode and authorization.

        //The protocol 'net.msmq' is not supported error while accesing from IIS - so addded the binding in application and website group but got below error after that
        //No protocol binding matches the given address 'net.msmq://localhost/private/QueueService'. Protocol bindings are configured at the Site level in IIS or WAS configuration.
        //Reason for above error is that I didn't give proper server name in bindinginformation field while adding net.msmq binding . It should be "localhost". Added it properly , it resolved the error

    }


    //Transactional Queue based MSMQ WCF service
    //Start the Distributed Transaction Cooredinator Windows service in the machine to enable Transacional queue to work
    [ServiceContract]
    public interface IQueueTransactService
    {

        [OperationContract(IsOneWay = true)] //Operations marked with IsOneWay=true must not declare output parameters, by-reference parameters or return values.It must be void
        void GetDataT(string value);

    }


    //Note : Not able to enable both Transactional and Non Transactional Queue based binding configuration together. So keeping only one active . Its fine
    //    <netMsmqBinding>
    //  <!--Non Transactional-->
    //  <!--<binding name = "MsmqBindingConfigNonTransact" exactlyOnce="false">
    //    <security mode = "None" />
    //  </ binding > -->
    //  < !--Transactional-- >
    //  < binding name="MsmqBindingConfigTransact" exactlyOnce="true">
    //    <security mode = "Transport" ></ security >
    //  </ binding >
    //</ netMsmqBinding >


    //          < !--< endpoint address="net.msmq://localhost/private/QueueService"     binding="netMsmqBinding"   contract="MSMQ_WCF.IQueueNonTransactService"  bindingConfiguration="MsmqBindingConfigNonTransact"     />-->
    //  <endpoint address = "net.msmq://localhost/private/QueueTransactService"     binding="netMsmqBinding"  contract="MSMQ_WCF.IQueueTransactService"     bindingConfiguration="MsmqBindingConfigTransact"     />




    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
