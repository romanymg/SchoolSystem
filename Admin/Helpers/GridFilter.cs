namespace Admin.Helpers
{
    public class GridFilter
    {
        public string? filterKey = "";
        public bool FilterData<TEntity>(TEntity searchMode)
        {
            if (string.IsNullOrWhiteSpace(filterKey)) return true;
            if (searchMode != null)
            {
                foreach (var item in typeof(TEntity).GetProperties())
                {
                    var val = item.GetValue(searchMode);

                    if (val != null)
                    {
                        if (val != null && val.ToString().Contains(filterKey.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
