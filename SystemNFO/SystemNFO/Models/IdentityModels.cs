using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SystemNFO.Models
{
  
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "ФИО")]
        public string Fio { get; set; }
        [Display(Name = "Должность")]
        public string Position { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
        
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            return userIdentity;
        }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
      
     
     
    }
    public class Organization
    {
        [Display(Name = "Номер организации")]
        public int OrganizationId { get; set; }
        [Display(Name = "ОГРН")]
        public long Ogrn { get; set; }
        [Display(Name = "Название организации")]
        public string Nameorg { get; set; }
        [Display(Name = "Сокращенное название")]
        [Required(ErrorMessage = "Это поле пусто.")]
        public string Socrnameorg { get; set; }
        [Display(Name = "Статус")]
        public string Status { get; set; }
        [Display(Name = "Вид организации")]
        public string Vidorg { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
        [Display(Name = "Риск-профиль")]
        public string Risc { get; set; }
        [Display(Name = "Режим надзора")]
        public int Mode { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }

    }
    public class Event
    {
        [Display(Name = "Номер мероприятия")]
        public int EventId { get; set; }
        [Display(Name = "Название мероприятия")]
        public string Nameevent { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Комментарий")]
        public string Comment { get; set; }
        [Display(Name = "Дата начала")]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime? Databegin { get; set; }
        [Display(Name = "Статуc")]
        public string Status { get; set; }
        [Display(Name = "Дата окончания")]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime? Dataend { get; set; }
        [Display(Name = "Дата переноса")]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime? Dataperenos { get; set; }
        [Display(Name = "Плановая дата")]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime? Dataplan { get; set; }
        [Display(Name = "Дата контроля")]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime Datacontrol { get; set; }
        [Display(Name = "Надзорный факт")]
        public string Nadzorfact { get; set; }
        [Display(Name = "Результат надзора")]
        public string Result { get; set; }
        [Display(Name = "Режим надзора")]
        public int Mode { get; set; }
       

    }
    public class SuperMode
    {
        [Display(Name = "Номер надзора")]
        public int SuperModeId { get; set; }
        [Display(Name = "ОГРН")]
        public long Ogrn { get; set; }
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Документ")]
        public string Document { get; set; }
        [Display(Name = "Вид объекта")]
        public string Vid { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
        [Display(Name = "Режим")]
        public int Mode { get; set; }
        [Display(Name = "Название режима надзора")]
        public string Namemode { get; set; }
    }
    public class Cur
    {
        [Display(Name = "Номер организации")]
        public int CurId { get; set; }
        [Display(Name = "ОГРН")]
        public long Ogrn { get; set; }
       [Display(Name = "Сокращенное название")]
        [Required(ErrorMessage = "Это поле пусто.")]
        public string Socrnameorg { get; set; }
        
    }
    public class OrgCur
    {
        [Display(Name = "Номер организации")]
        public int OrgCurId { get; set; }
        [Display(Name = "ОГРН")]
        public long Ogrn { get; set; }
        [Display(Name = "Сокращенное название организации")]
        [Required(ErrorMessage = "Это поле пусто.")]
        public string Socrnameorg { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
    public class OrganizationCurator
    {
        [Display(Name = "Номер организации")]
        public int OrganizationCuratorId { get; set; }
        [Display(Name = "ОГРН")]
        public long Ogrn { get; set; }
        [Display(Name = "Сокращенное название организации")]
        [Required(ErrorMessage = "Это поле пусто.")]
        public string Socrnameorg { get; set; }
        [Display(Name = "Куратор")]
        public string FIO { get; set; }

    }
  
    //public class DoubleModel
    //{

    //    public long Ogrn { get; set; }
    //    public string Socrnameorg { get; set; }
    //    public string FIO { get; set; }
    //    public DoubleModel() { }
    //}
    public class ListOrganizationViewModel
    {
        public List<Organization> Organizations { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<SuperMode> SuperModes { get; set; }
        public DbSet<Cur> Curs { get; set; }
        public DbSet<OrgCur> OrgCurs { get; set; }
        public DbSet<OrganizationCurator> OrganizationCurators { get; set; }
        //public DbSet<DoubleModel> DoubleModels { get; set; }
        // public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

      //  public System.Data.Entity.DbSet<SystemNFO.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<SystemNFO.Models.ApplicationUser> ApplicationUsers { get; set; }


    }
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "curator" };
             var role3 = new IdentityRole { Name = "chief" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
            // создаем пользователей
            var admin = new ApplicationUser { Email = "administrator@gmail.com", UserName = "administrator@gmail.com", Fio = "Иванов Иван Иванович", Position = "Администратор" };
            string password = "Admin123@";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
                userManager.AddToRole(admin.Id, role3.Name);
            }

            base.Seed(context);
        }
    }
}