using Microsoft.AspNetCore.Mvc.RazorPages;

public class DemoModel : PageModel
{
    public int NumberOfItems => items.Count();
    public int PageSize => 5;
    public int CurrentPage { get; set; }
    public bool LastPage => CurrentPage == NumberOfPages;
    public bool FirstPage => CurrentPage == 1;
    public int NumberOfPages => GetNumberOfPages();

    private IEnumerable<string> items = new List<string>{
            "Kalle", "Olle", "Lisa", "Gustav",
            "Niklas", "Karin", "Axel", "Alex",
            "Håkan", "Peter", "Viktoria", "Malin",
            "Vanessa", "Mary", "Arja", "Dan", "Anna",
            "Cecilia", "Monika", "Katrin", "Nisse",
            "Petra", "Thomas", "Peter", "Petter",
            "Fred", "Wilma", "Joakim", "Jakob",
            "Mika", "George", "Bill", "Bull"
        };

    public IEnumerable<string> Items { get; private set; }

    public DemoModel()
    {
        Items = new List<string>();
    }

    public void OnGet(int p)
    {
        CurrentPage = p > 0
            ? CurrentPage = p
            : CurrentPage = 1;

        // Get items from repository
        Items = items.Skip((p - 1) * PageSize).Take(PageSize);
    }

    private int GetNumberOfPages()
    {
        return NumberOfItems % PageSize == 0
                ? NumberOfItems / PageSize
                : NumberOfItems / PageSize + 1;
    }
}
