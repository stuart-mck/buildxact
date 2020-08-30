namespace buildxact_supplies.Domain.Supplier
{
    public class SupplierEntity
    {
        public string Key { get; set; }

        public string Supplier { get; set; }

        public string ItemId { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        //todo: what other fields? need to capture extra data present in the mega list

    }
}
