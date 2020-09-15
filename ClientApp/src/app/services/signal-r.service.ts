import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Chartmodel } from '../_interfaces/chartmodel.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  public data: Chartmodel[];
  public stringdata: string;
  private hubConnection: signalR.HubConnection;
  startConnection() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:52520/timer')
     // .configureLogging(signalR.LogLevel.Debug)
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection opened'))
      .catch((err) => console.log('Error while starting connection', err));

  }
  stopConnection() {
    this.hubConnection.stop()
      .catch(err => console.log(err))
      .finally( () => console.log("end stop"));
  }
  addTransferDataListener() {
    this.hubConnection.on('transfertime', (data) => {
      this.stringdata = data;
      console.log("Data received: ", data);
    })
  }
  constructor() { }
}
