//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Receiver
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Receiver()
        {
            this.Orders = new HashSet<Order>();
        }
    
        /// <summary>
    	/// 
    	/// </summary>
    	public long Id { get; set; }
        /// <summary>
    	/// 
    	/// </summary>
    	public long MemberId { get; set; }
        /// <summary>
    	/// 
    	/// </summary>
    	public string Name { get; set; }
        /// <summary>
    	/// 
    	/// </summary>
    	public string Phone { get; set; }
        /// <summary>
    	/// 
    	/// </summary>
    	public int Area { get; set; }
        /// <summary>
    	/// 
    	/// </summary>
    	public string Address { get; set; }
        /// <summary>
    	/// 
    	/// </summary>
    	public bool IsDefault { get; set; }
        /// <summary>
    	/// 
    	/// </summary>
    	public System.DateTime CreateTime { get; set; }
        /// <summary>
    	/// 
    	/// </summary>
    	public System.DateTime UpdateTime { get; set; }
        /// <summary>
    	/// 
    	/// </summary>
    	public Nullable<System.DateTime> UseTime { get; set; }
    
        public virtual Member Member { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
