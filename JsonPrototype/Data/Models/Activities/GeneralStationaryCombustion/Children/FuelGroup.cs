namespace JsonPrototype.Data
{
    public class FuelGroup : NestedActivity
    {
        public override string ActivityName { get; } = "FuelGroup";
        public override Guid ParentActivityId { get; set; }

        public string GscUnitName { get; set; }
        public string Description { get; set; }
        public List<Fuel> Fuels { get; set; }
    }
}
