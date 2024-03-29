﻿namespace BlazorRealTimeData.Data
{
    public class Message
    {
        public int Id { get; set; }
        public int RegNum { get; set; }
        public string Sender { get;set; }
        public string Title { get; set; }
        public string Reciever { get; set; }
        public string Status { get; set; }
        public string RegDate { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}\nRegNum: {RegNum}\nSender: {Sender}\nTitle: {Title}\nReciever: {Reciever}\nStatus: {Status}\nRegDate: {RegDate}";
        }
    }
}