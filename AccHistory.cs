using System;
namespace Bank
{
    public class AccHistory
    {
        public type opptype;
        public int sender;
        public int receiver;
        public int oppAmount;

        public enum type
        {
            payment, withdraw, transfer, creditGot, creditPayed
        }

        public void print()
        {
            Console.WriteLine("Type: {0} Sender: {1} Receiver: {2} Amount: {3}", opptype, sender, receiver, oppAmount);
        }
        public AccHistory(type type, int senderAcc, int receiverAcc, int amount)
        {
            opptype = type;
            sender = senderAcc;
            receiver = receiverAcc;
            oppAmount = amount;
        }

    }
}