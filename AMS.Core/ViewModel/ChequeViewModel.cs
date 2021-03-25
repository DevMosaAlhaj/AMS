﻿using System;

namespace AMS.Core.ViewModel
{
    public class ChequeViewModel : IBaseViewModel
    {

        public int Id { get; set; }
        
        public DateTime DueAt { get; set; }

        public string ByBank { get; set; }
        
        public int Amount { get; set; }

        public string Currency { get; set; }

        public string DebtorName { get; set; }

        public int TransactionId { get; set; }

        public bool IsPaid { get; set; }
    }

   
}