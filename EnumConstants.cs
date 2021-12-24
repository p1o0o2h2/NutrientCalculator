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
    /// データベースでの列数(=1始まり)なのでlistの時は-1
    /// </summary>
    enum NutrientDataColumn
    {
        genre=1,
        identify=3,
        name =4, 
        refuse=5
    }
}
