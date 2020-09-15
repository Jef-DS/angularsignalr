import { Component,OnInit } from '@angular/core';
import { SignalRService } from './services/signal-r.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';
  data: object;
  constructor(public signalRService: SignalRService,
    private http: HttpClient) {

  }
  ngOnInit(): void {
    this.startHttpRequest();
  }
  startHttpRequest() {
    this.http.get('http://localhost:52520/api/timer')
      .subscribe(res => {
        this.data = res;
        console.log(res);
      })
  }
  start() {
    this.signalRService.startConnection();
    this.signalRService.addTransferDataListener();
  }
  stop() {
    this.signalRService.stopConnection();
  }
}
