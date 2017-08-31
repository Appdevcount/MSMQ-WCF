using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MSMQWCF.QueueTransactServiceClient QS = new MSMQWCF.QueueTransactServiceClient();
            QS.GetDataTAsync("88");
        }
        private static void SendMessageToQueue(string queueName)
        {
            // check if queue exists, if not create it

            MessageQueue msMq = null;

            if (!MessageQueue.Exists(queueName))
            {
                msMq = MessageQueue.Create(queueName);
            }
            else
            {
                msMq = new MessageQueue(queueName);
            }

            try

            {
                // msMq.Send("Sending data to MSMQ at " + DateTime.Now.ToString());
                Person p = new Person()
                {
                    FirstName = "ITFunda",
                    LastName = ".Com"
                };
                msMq.Send(p);
            }
            catch (MessageQueueException ee)
            {
                Console.Write(ee.ToString());
            }
            catch (Exception eee)
            {
                Console.Write(eee.ToString());
            }

            finally
            {
                msMq.Close();
            }
            Console.WriteLine("Message sent ......");
        }
        private static void ReceiveMessageFromQueue(string queueName)
        {
            MessageQueue msMq = msMq = new MessageQueue(queueName);
            try
            {
                // msMq.Formatter = new XmlMessageFormatter(new Type[] {typeof(string)});

                msMq.Formatter = new XmlMessageFormatter(new Type[] { typeof(Person) });

                var message = (Person)msMq.Receive().Body;

                Console.WriteLine("FirstName: " + message.FirstName + ", LastName: " + message.LastName);

                // Console.WriteLine(message.Body.ToString());
            }
            catch (MessageQueueException ee)
            {
                Console.Write(ee.ToString());
            }
            catch (Exception eee)
            {
                Console.Write(eee.ToString());
            }
            finally
            {
                msMq.Close();
            }
            Console.WriteLine("Message received ......");
        }
    }
}
