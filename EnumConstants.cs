namespace えいようちゃん
{
    enum TimingType
    {
        none = -1,
        breakfast,
        lunch,
        dinner,
        snack
    }
    enum FileType
    {
        none = -1,
        free,
        set,
        day,
        serve
    }

    enum DishType
    {
        none = -1,
        staple,
        soup,
        maindish,
        sidedish
    }
    
    /// <summary>
    /// 食品成分表の各項目の列数
    /// データベースでの列数(=1始まり)なのでlistの時は-1 idone~molybdenumまで連番(31~34)
    /// </summary>
    enum NutrientDataColumn
    {
        genre=1,
        identify=3,
        name =4, 
        refuse=5,
        //以下Trの条件が3/10
        iodine=31,
        selen=32,
        chromium=33,
        molybdenum=34,
        biotin=55
    }
}
