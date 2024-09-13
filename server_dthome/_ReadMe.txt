----database first, xong vào tool chạy:
Scaffold-DbContext "Data Source=GREEND;Initial Catalog=DTHome;Integrated Security=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Entities
    
Scaffold-DbContext "Data Source=GREEND;Initial Catalog=DTHome;Integrated Security=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Entities -f

-- để generate lại thì gõ -f