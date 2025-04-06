using System;
using System.Collections.Generic;

namespace УчебнаяНагрузка1.Model;

public partial class Дисциплины
{
    public int Код { get; set; }

    public string? Название { get; set; }

    public string? Направление { get; set; }

    public virtual ICollection<Преподаватели> Преподавателиs { get; set; } = new List<Преподаватели>();
}
