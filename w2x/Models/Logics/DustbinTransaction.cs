using System;
namespace w2x.Models.Logics
{
	public class DustbinTransaction
	{
		public Guid TransactionId { get; set; }
		public float Debit { get; set; }
		public float Credit { get; set;}

		public DustbinTransaction() { }
		public DustbinTransaction(Guid TransactionId, float Debit, float Credit)
		{
			this.TransactionId = TransactionId;
			this.Debit = Debit;
			this.Credit = Credit;
		}
	}
}
