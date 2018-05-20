namespace StockAnalyticsLib

module public DataModel =
    open System   
    type OHCL = {Open: decimal; High: decimal; Close: decimal; Low: decimal; Date: DateTime}

    type Direction = 
      | Up
      | Down
      | Side

    type DayChangeData = {Close: decimal; Change: decimal; ``ChangeIn%``: decimal; Date: DateTime} 

module demo = 
    open FSharp.Data
    open DataModel
    type MsftCsvProvider =  CsvProvider<"MSFT.csv",  ";">
    let data = MsftCsvProvider.Load("MSFT.csv");

    
    let GetDirection prev curr = 
       if prev < curr then 
           Direction.Up
       else if curr < prev then
           Direction.Down
       else 
           Direction.Side
   
    let CountTrend (trend: Direction) (cur: OHCL) (prev: OHCL) counter  = 
        let dir = GetDirection cur.Close prev.Close;
        if(dir = trend) then 
            counter+1
        else 
            counter
   
    let rec ProcessList list prev retData predicate =
       match list with
           | head::tail -> ProcessList tail head (predicate prev head retData) predicate
           | [] -> retData
       
    let GetDayData (prev: OHCL) (curr: OHCL) =
       { Close = curr.Close; Change = (curr.Close - prev.Close); ``ChangeIn%``= (((curr.Close - prev.Close) / curr.Close) * 100M); Date = curr.Date}
   
    let ProcessDayData prev curr list =
       let n = GetDayData prev curr
       n::list

module public FsStockLib = 
    open DataModel
    open demo

    let ReadCsv = 
        async{
            let! cc = MsftCsvProvider.AsyncLoad("MSFT.csv");
            return cc.Rows 
                        |> Seq.map (fun f -> {Open = f.Open; Close = f.Close; Low = f.Min; High = f.Max; Date = f.Date}) 
                        |> Seq.sortBy(fun f -> f.Date)
        } |> Async.StartAsTask
    
    let NumberOfDaysInPlus seqData =
        let rows = seqData |> Seq.toList
        ProcessList (rows |> List.tail) (rows |> List.head) 0 (CountTrend Up)  
    
    let NumberOfDaysInNegative seqData =
        let rows = seqData |> Seq.toList
        ProcessList (rows |> List.tail) (rows |> List.head) 0 (CountTrend Down)  
    
    let ChangesPerDayAsync = 
        async{
            let! cc = MsftCsvProvider.AsyncLoad("MSFT.csv");
            let rows = cc.Rows 
                    |> Seq.map (fun f -> {Open = f.Open; Close = f.Close; Low = f.Min; High = f.Max; Date = f.Date}) 
                    |> Seq.sortBy(fun f -> f.Date) 
                    |> Seq.toList 
            return ProcessList (rows |> List.tail) (rows |> List.head) [] ProcessDayData 
                    |> List.toSeq
        } |> Async.StartAsTask