using System;
using System.Collections.Generic;

namespace УчебнаяНагрузка1.Model;

public partial class РаспределениеНагрузки
{
    public int Ключ { get; set; }

    public int? ТабельныйНомерПрепода { get; set; }

    public int? НомерГруппы { get; set; }

    public int? Семестр { get; set; }

    public int? КоличествоЧасов { get; set; }

    public virtual Преподаватели? ТабельныйНомерПреподаNavigation { get; set; }
}
