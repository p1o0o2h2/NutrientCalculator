using ClosedXML.Excel;
using System;
using System.Collections.Generic;

namespace えいようちゃん
{
    /// <summary>
    /// ファイルを外部ソフトに出力
    /// </summary>
    static public class Output
    {
        /// <summary>
        ///Excelワークシートを作成
        /// </summary>              
        static public void OutputNutrientValueForXlsx(List<List<string>>table,string pass)
        {
            var workBook = new XLWorkbook();
            var workSheet=workBook.AddWorksheet(MainForm.File.FileName);

            int rowIndex = 0;
            int columnIndex = 0;

            while(columnIndex<table[0].Count)
            {
                var columns = new List<string>();
                while (rowIndex < table.Count)
                {
                    columns.Add(table[rowIndex][columnIndex]);
                    rowIndex++;
                }
                rowIndex = 0;
                WorkSheetAddValues(columns, columnIndex);
                columnIndex++;
            }

            try
            {
                workBook.SaveAs(pass);
            }
            catch(Exception e)
            {
                int count = 0;
                if(count<3)
                {
                    //3回エラーになるまでリトライする
                    count++;
                    workBook.SaveAs(pass);
                }
                else
                {
                    throw new Exception($"ファイルの書き込みに失敗しました\n{e.Message}");
                }
            }
           
            ///各セルに値をセット、mergeが上手く行ってるか分からない
           void WorkSheetAddValues(List<string> columns,int columnIndex)
            {
                int margeStartRange = 0;
                for(int i=0;i<columns.Count;i++)
                {
                    if (columns[i] == "")
                    {
                        margeStartRange = i + 1;
                    }
                    else if (margeStartRange > 0)
                    {
                        workSheet.Range(workSheet.Cell(margeStartRange, columnIndex).Address, workSheet.Cell(i, columnIndex).Address);
                        margeStartRange = 0;
                    }
                    else
                    {
                        workSheet.Cell(i + 1, columnIndex + 1).Value = columns[i];
                    }                    
                }
                if(margeStartRange>0)
                {
                    workSheet.Range(workSheet.Cell(margeStartRange, columnIndex+1).Address, workSheet.Cell(columns.Count, columnIndex+1).Address);
                }
            }
        }
    }
}