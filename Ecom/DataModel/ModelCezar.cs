namespace Ecom.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelCezar : DbContext
    {
        public ModelCezar()
            : base("name=ModelCezar")
        {
        }

        public virtual DbSet<ADDRESS> ADDRESS { get; set; }
        public virtual DbSet<ADVICE> ADVICE { get; set; }
        public virtual DbSet<CATEGORY> CATEGORY { get; set; }
        public virtual DbSet<CATEGORY_INGREDIENT> CATEGORY_INGREDIENT { get; set; }
        public virtual DbSet<INGREDIENT> INGREDIENT { get; set; }
        public virtual DbSet<ITEM> ITEM { get; set; }
        public virtual DbSet<item_selection> item_selection { get; set; }
        public virtual DbSet<MENU> MENU { get; set; }
        public virtual DbSet<menu_selection> menu_selection { get; set; }
        public virtual DbSet<ORDERS> ORDERS { get; set; }
        public virtual DbSet<ORDERS_STATUS> ORDERS_STATUS { get; set; }
        public virtual DbSet<ORDERS_TYPE> ORDERS_TYPE { get; set; }
        public virtual DbSet<TAG> TAG { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADDRESS>()
                .Property(e => e.address_title)
                .IsUnicode(false);

            modelBuilder.Entity<ADDRESS>()
                .Property(e => e.street_name)
                .IsUnicode(false);

            modelBuilder.Entity<ADDRESS>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<ADVICE>()
                .Property(e => e.advice1)
                .IsUnicode(false);

            modelBuilder.Entity<ADVICE>()
                .Property(e => e.id_user)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.category_title)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .Property(e => e.category_description)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.ITEM)
                .WithRequired(e => e.CATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CATEGORY_INGREDIENT>()
                .Property(e => e.category_ingredient_title)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY_INGREDIENT>()
                .Property(e => e.category_ingredient_description)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORY_INGREDIENT>()
                .HasMany(e => e.INGREDIENT)
                .WithRequired(e => e.CATEGORY_INGREDIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INGREDIENT>()
                .Property(e => e.ingredient_title)
                .IsUnicode(false);

            modelBuilder.Entity<INGREDIENT>()
                .Property(e => e.ingredient_description)
                .IsUnicode(false);

            modelBuilder.Entity<INGREDIENT>()
                .Property(e => e.ingredient_image)
                .IsUnicode(false);

            modelBuilder.Entity<INGREDIENT>()
                .Property(e => e.ingredient_price)
                .HasPrecision(15, 3);

            modelBuilder.Entity<INGREDIENT>()
                .HasMany(e => e.item_selection)
                .WithRequired(e => e.INGREDIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INGREDIENT>()
                .HasMany(e => e.menu_selection)
                .WithRequired(e => e.INGREDIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INGREDIENT>()
                .HasMany(e => e.ITEM)
                .WithMany(e => e.INGREDIENT)
                .Map(m => m.ToTable("have").MapLeftKey("id_ingredient").MapRightKey("id_item"));

            modelBuilder.Entity<ITEM>()
                .Property(e => e.item_title)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.item_decription)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.item_image)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.item_price)
                .HasPrecision(15, 3);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.item_promotion_price)
                .HasPrecision(15, 3);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.ADVICE)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.item_selection)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.MENU)
                .WithRequired(e => e.ITEM)
                .HasForeignKey(e => e.id_item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.menu_selection)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.MENU1)
                .WithMany(e => e.ITEM1)
                .Map(m => m.ToTable("composed").MapLeftKey("id_item").MapRightKey("id_menu"));

            modelBuilder.Entity<item_selection>()
                .Property(e => e.item_selection_note)
                .IsUnicode(false);

            modelBuilder.Entity<MENU>()
                .Property(e => e.menu_title)
                .IsUnicode(false);

            modelBuilder.Entity<MENU>()
                .Property(e => e.menu_description)
                .IsUnicode(false);

            modelBuilder.Entity<MENU>()
                .Property(e => e.menu_price)
                .HasPrecision(15, 3);

            modelBuilder.Entity<MENU>()
                .Property(e => e.menu_promotion_price)
                .HasPrecision(15, 3);

            modelBuilder.Entity<MENU>()
                .HasMany(e => e.menu_selection)
                .WithRequired(e => e.MENU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<menu_selection>()
                .Property(e => e.menu_selection_note)
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.orders_number)
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.orders_price)
                .HasPrecision(15, 3);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.orders_date)
                .HasPrecision(0);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.orders_delay_date)
                .HasPrecision(0);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.id_user)
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS>()
                .HasMany(e => e.item_selection)
                .WithRequired(e => e.ORDERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDERS>()
                .HasMany(e => e.menu_selection)
                .WithRequired(e => e.ORDERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDERS_STATUS>()
                .Property(e => e.orders_status_title)
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS_STATUS>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.ORDERS_STATUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDERS_TYPE>()
                .Property(e => e.orders_type_title)
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS_TYPE>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.ORDERS_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAG>()
                .Property(e => e.tag_title)
                .IsUnicode(false);
        }
    }
}
