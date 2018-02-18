//Adapt this path
#r "C:\\Users\\[USERNAME]\\.nuget\\packages\\fsharp.data\\2.4.4\\lib\\net45\\Fsharp.Data.dll"
 
open FSharp.Data

module public DataModel =
    open System   
    type OHCL = {Open: decimal; High: decimal; Close: decimal; Low: decimal; Date: DateTime}

    type Direction = 
      | Up
      | Down
      | Side

    type DayChangeData = {Close: decimal; Change: decimal; ``ChangeIn%``: decimal; Date: DateTime} 

module demo = 
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
   
    let CountTrend (trend: Direction) cur prev counter  = 
        let dir = GetDirection cur prev;
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

    let first = data.Rows |> Seq.tail |> Seq.head 
    first.Close   

    let rows = data.Rows 
               |> Seq.map (fun f -> {Open = f.Open; Close = f.Close; Low = f.Min; High = f.Max; Date = f.Date}) 
               |> Seq.sortBy(fun f -> f.Date) 
               |> Seq.toList 
    
    let up = ProcessList (rows |> List.tail) (rows |> List.head) 0 (CountTrend Side)  
    
    let down = ProcessList (rows |> List.tail) (rows |> List.head) 0 (CountTrend Side)  
    
    let dayDataList = ProcessList (rows |> List.tail) (rows |> List.head) [] ProcessDayData


    