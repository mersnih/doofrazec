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
        public virtual DbSet<ITEM_OPTION_MENU> ITEM_OPTION_MENU { get; set; }
        public virtual DbSet<item_selection> item_selection { get; set; }
        public virtual DbSet<MENU> MENU { get; set; }
        public virtual DbSet<OPTION_CHOIX_MENU> OPTION_CHOIX_MENU { get; set; }
        public virtual DbSet<ORDERS> ORDERS { get; set; }
        public virtual DbSet<ORDERS_STATUS> ORDERS_STATUS { get; set; }
        public virtual DbSet<ORDERS_TYPE> ORDERS_TYPE { get; set; }
        public virtual DbSet<PAYEMENT_DETAIL> PAYEMENT_DETAIL { get; set; }
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
                .Property(e => e.category_button_color)
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

            modelBuilder.Entity<CATEGORY_INGREDIENT>()
                .HasMany(e => e.ITEM)
                .WithMany(e => e.CATEGORY_INGREDIENT)
                .Map(m => m.ToTable("have").MapLeftKey("id_category_ingredient").MapRightKey("id_item"));

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
                .HasPrecision(15, 2);

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
                .HasPrecision(15, 2);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.item_promotion_price)
                .HasPrecision(15, 2);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.item_button_color)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.ADVICE)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.ITEM_OPTION_MENU)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.item_selection)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

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
                .HasMany(e => e.OPTION_CHOIX_MENU)
                .WithMany(e => e.MENU)
                .Map(m => m.ToTable("Options_Menu").MapLeftKey("id_menu").MapRightKey("id_option_choix_menu"));

            modelBuilder.Entity<OPTION_CHOIX_MENU>()
                .Property(e => e.option_choix_menu_title)
                .IsUnicode(false);

            modelBuilder.Entity<OPTION_CHOIX_MENU>()
                .HasMany(e => e.ITEM_OPTION_MENU)
                .WithRequired(e => e.OPTION_CHOIX_MENU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.orders_number)
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.orders_price)
                .HasPrecision(15, 2);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.orders_leftToPay)
                .HasPrecision(15, 2);

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
                .HasMany(e => e.PAYEMENT_DETAIL)
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

            modelBuilder.Entity<PAYEMENT_DETAIL>()
                .Property(e => e.way)
                .IsUnicode(false);

            modelBuilder.Entity<PAYEMENT_DETAIL>()
                .Property(e => e.payement_detail_price)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TAG>()
                .Property(e => e.tag_title)
                .IsUnicode(false);
        }
    }
}
