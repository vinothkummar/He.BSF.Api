namespace He.BSF.Core.Models
{
	public class DocumentItem : Entity
	{
        /// <summary>
        /// DocumentItem item name
        /// </summary>
        /// <example>Grocery</example>
        public string Name { get; set; }

        /// <summary>
        /// DocumentItem item Description
        /// </summary>
        /// <example>Pick Bread</example>
        public string Description { get; set; }
   
        /// <summary>
        /// DocumentItem item category
        /// </summary>
        /// <example>Shopping</example>
        public string Category { get; set; }
	}
}
