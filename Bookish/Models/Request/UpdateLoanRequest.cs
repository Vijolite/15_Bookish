﻿using System.ComponentModel.DataAnnotations;


namespace Bookish.Models.Request
{
    public class UpdateLoanRequest
    {
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int CopyId { get; set; }
        

        // public DateTime IssueDate { get; set; }
        // public DateTime? ReturnDate { get; set; }
        // public bool HasReturned { get; set; }
        public UpdateLoanRequest() {
        }
        public UpdateLoanRequest(Loan loan)
        {
            MemberId = loan.Member.Id; 
            CopyId = loan.Copy.CopyId;
        }


    }
}