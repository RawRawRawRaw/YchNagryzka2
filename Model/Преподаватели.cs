using System;
using System.Collections.Generic;

namespace УчебнаяНагрузка1.Model;

public partial class Преподаватели
{
    public int ТабельныйНомер { get; set; }

    public string? Фамилия { get; set; }

    public string? Имя { get; set; }

    public string? Отчество { get; set; }

    public string? Должность { get; set; }

    public int? Кафедра { get; set; }

    public int? Стаж { get; set; }

    public virtual Дисциплины? КафедраNavigation { get; set; }

    public virtual ICollection<РаспределениеНагрузки> РаспределениеНагрузкиs { get; set; } = new List<РаспределениеНагрузки>();
}
