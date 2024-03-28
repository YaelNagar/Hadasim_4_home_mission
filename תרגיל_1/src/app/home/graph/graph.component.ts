import { Component, OnInit } from '@angular/core';
import { CoronaPatientsService } from 'src/app/services/corona-patients.service';

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.css']
})
export class GraphComponent implements OnInit {

  chartOptions = {
    title: {
      text: "מספר חולי הקורונה בכל יום בחודש האחרון"
    },
    data: [{
      type: "column",
      dataPoints: [
        { label: "1", y: 0 },
        { label: "2", y: 0 },
        { label: "3", y: 0 },
        { label: "4", y: 0 },
        { label: "5", y: 0 },
        { label: "6", y: 0 },
        { label: "7", y: 0 },
        { label: "8", y: 0 },
        { label: "9", y: 0 },
        { label: "10", y: 0 },
        { label: "11", y: 0 },
        { label: "12", y: 0 },
        { label: "13", y: 0 },
        { label: "14", y: 0 },
        { label: "15", y: 0 },
        { label: "16", y: 0 },
        { label: "17", y: 0 },
        { label: "18", y: 0 },
        { label: "19", y: 0 },
        { label: "20", y: 0 },
        { label: "21", y: 0 },
        { label: "22", y: 0 },
        { label: "23", y: 0 },
        { label: "24", y: 0 },
        { label: "25", y: 0 },
        { label: "26", y: 0 },
        { label: "27", y: 0 },
        { label: "28", y: 0 },
        { label: "29", y: 0 },
        { label: "30", y: 0 },
        { label: "31", y: 0 }
      ]
    }]
  };

  constructor(public coronaPatientsService: CoronaPatientsService) { }

  ngOnInit(): void {
    this.getLastMonthCoronaPatients()
    debugger
  }

  getLastMonthCoronaPatients() {
    this.coronaPatientsService.LastMonthCoronaPatients().subscribe(
      res => {
        res.forEach(x => {
          let b= this.chartOptions.data[0].dataPoints.find(o=>o.label==String(x.Key));
          if(b) b.y=x.Value;
        })
      },
      err => {
        console.log(err);
      }
    )
  }
}
