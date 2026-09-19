namespace DiscountManegment.Application.Contract.ColleagueDiscountApplication;

public class ColleagueDiscountViewModel
{
    public long Id { get; set; }
    public long PoroductId { get; set; }
    public string product { get; set; }
    public int DiscountRate { get; set; }
    public string CreateDateTime { get; set; }
    public bool Isdeleted { get; set; }
}