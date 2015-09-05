using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace famiLYNX.Domain {
    public class Address {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public StName State { get; set; }

        [RegularExpression(@"^\d{5}$")]
        public string Zip { get; set; }
    }

    
    public enum StName {
        None,
        Alabama,
        Alaska,
        Arizona,
        Arkansas,
        California,
        Colorado,
        Connecticut,
        Deleware,
        Georgia,
        Florida,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        New_Hamshire,
        New_Jersey,
        New_Mexico,
        New_York,
        North_Carolina,
        North_Dakota,
        Ohio,
        Oklahoma,
        Oregon,
        Pennsylvania,
        Rhode_Island,
        South_Carolina,
        South_Dakota,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Virginia,
        Washington,
        West_Virginia,
        Wisconsin,
        Wyoming
    }
    
}