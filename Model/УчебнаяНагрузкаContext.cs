using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace УчебнаяНагрузка1.Model;

public partial class УчебнаяНагрузкаContext : DbContext
{
    public УчебнаяНагрузкаContext()
    {
    }

    public УчебнаяНагрузкаContext(DbContextOptions<УчебнаяНагрузкаContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Дисциплины> Дисциплиныs { get; set; }

    public virtual DbSet<Преподаватели> Преподавателиs { get; set; }

    public virtual DbSet<РаспределениеНагрузки> РаспределениеНагрузкиs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-AUUBG2G\\SQLEXPRESS02; Database=УчебнаяНагрузка; Encrypt=false; Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Дисциплины>(entity =>
        {
            entity.HasKey(e => e.Код).HasName("PK__Дисципли__AE76132EA4E72F99");

            entity.ToTable("Дисциплины");

            entity.Property(e => e.Код).ValueGeneratedNever();
            entity.Property(e => e.Название).HasMaxLength(50);
            entity.Property(e => e.Направление).HasMaxLength(50);
        });

        modelBuilder.Entity<Преподаватели>(entity =>
        {
            entity.HasKey(e => e.ТабельныйНомер).HasName("PK__Преподав__35557920A64219F0");

            entity.ToTable("Преподаватели");

            entity.Property(e => e.ТабельныйНомер).ValueGeneratedNever();
            entity.Property(e => e.Должность).HasMaxLength(50);
            entity.Property(e => e.Имя).HasMaxLength(50);
            entity.Property(e => e.Отчество).HasMaxLength(50);
            entity.Property(e => e.Фамилия).HasMaxLength(50);

            entity.HasOne(d => d.КафедраNavigation).WithMany(p => p.Преподавателиs)
                .HasForeignKey(d => d.Кафедра)
                .HasConstraintName("FK_Преподаватели_Дисциплины");
        });

        modelBuilder.Entity<РаспределениеНагрузки>(entity =>
        {
            entity.HasKey(e => e.Ключ).HasName("PK__Распреде__04C85F6A6D357D7A");

            entity.ToTable("РаспределениеНагрузки");

            entity.Property(e => e.Ключ).ValueGeneratedNever();

            entity.HasOne(d => d.ТабельныйНомерПреподаNavigation).WithMany(p => p.РаспределениеНагрузкиs)
                .HasForeignKey(d => d.ТабельныйНомерПрепода)
                .HasConstraintName("FK_РаспределениеНагрузки_Преподаватели");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
