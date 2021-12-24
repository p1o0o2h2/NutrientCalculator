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
        static public string  margeSign = "=Marge()";
        static public string  emptySign = " ";
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

            int count = 0;
            try
            {
                workBook.SaveAs(pass);
            }
            catch(Exception e)
            {
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
           
            ///各セルに値をセット
           void WorkSheetAddValues(List<string> columns,int columnIndex)
            {
                int margeStartRange =0;
                for(int i=0;i<columns.Count;i++)
                {
                    if(margeStartRange>0)
                    {
                        if (columns[i] !=margeSign)
                        {
                            var startCell = workSheet.Cell(margeStartRange, columnIndex + 1).Address;
                            var endCell = workSheet.Cell(i, columnIndex + 1).Address;
                            workSheet.Range(startCell,endCell).Merge();
                            margeStartRange = 0;
                        }
                    }
                    else if(columns[i] ==margeSign)
                    {
                        margeStartRange = i;
                    }
                    else
                    {
                        workSheet.Cell(i + 1, columnIndex + 1).Value = columns[i];
                    }
                }                
            }
        }
    }
}