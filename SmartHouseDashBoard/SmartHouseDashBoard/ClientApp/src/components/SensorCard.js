import React, { Component } from 'react';
import DashBoardService from '../Services/DashboardService'

export class SensorCard extends Component {


  constructor(props) {
    super(props);
    this.state = {buildings:[], sensors: [], rooms:[], loading: true };
  }

  componentDidMount() {
    this.getBuildings();
    this.getRooms(1);
    this.getSensors(2);
  }

  static renderSensorsTable(sensors) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Sensor</th>
            <th>Value</th>
            <th>Unit</th>
          </tr>
        </thead>
        <tbody>
          {sensors.map(sensor =>  
            <tr key={sensor.sensorId}>
              <td>{sensor.sensorName}</td>
              <td>{sensor.value}</td>
              <td>{sensor.unitOfMeasurement}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }
  static renderBuildingTable(buildings) {
    return (
      <ul id="myUL">
    <li><span className="caret" >Buildings</span>
    <ul className="nested">
    {
    buildings.map(building =>  
            <li key={building.buildingId}>
              {building.buildingName}
              {building.floors.length > 0 &&
    <ul className="nested">{
          building.floors.map(floor =>  
            <li key={floor.floorId} >
              {floor.floorName}
      </li>
          )}
          </ul>
      }
      </li>
          )}
    </ul>
  </li>
</ul>
    );
  }
  static renderRoomsTable(rooms) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Room</th>
          </tr>
        </thead>
        <tbody>
          {rooms.map(room =>  
            <tr key={room.roomId}>
              <td>{room.roomName}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }
 
  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : SensorCard.renderBuildingTable(this.state.buildings);

    return (
      <div>
        <h1 id="tabelLabel" >Room Parameters</h1>
        <p>Reading Latest Room Parameters</p>
        {contents}
        {SensorCard.renderRoomsTable(this.state.rooms)}
        {SensorCard.renderSensorsTable(this.state.sensors)}
      </div>
    );
  }

   sayHello(name) {
    alert(`hello, ${name}`);
  }
  async getBuildings() {
    let dataService=new DashBoardService();
    const data= await dataService.getAllBuildings();
    this.setState({ buildings: data, loading: false });
  }
  async getFloors(buidlingId) {
    let dataService=new DashBoardService();
    const data= await dataService.getFloorsByBuilding(buidlingId);
    this.setState({ sensors: data, loading: false });
  }
  async getRooms(floorId) {
    let dataService=new DashBoardService();
    const data= await dataService.getRoomsByFloor(floorId);
    this.setState({ rooms: data, loading: false });
  }
  async getSensors(roomId) {
    let dataService=new DashBoardService();
    const data= await dataService.getSensorsByRoom(roomId);
    this.setState({ sensors: data, loading: false });
  }
}
