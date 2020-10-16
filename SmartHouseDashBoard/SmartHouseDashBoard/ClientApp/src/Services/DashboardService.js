import Settings  from './Settings/Settings';
export default class DashBoardService
 {
    async getAllBuildings()
    {
           const response = await fetch(Settings.baseApiUrl+'buildings/');
           const data = await response.json();
           return data;
    };
  
    async getFloorsByBuilding(buildingId)
    {
           const response = await fetch(Settings.baseApiUrl+'buildings/'+buildingId+'/floors');
           const data = await response.json();
           return data;
    };
    async getRoomsByFloor(floorId)
    {
           const response = await fetch(Settings.baseApiUrl+'floors/'+floorId+'/rooms');
           const data = await response.json();
           return data;
    };
   async getSensorsByRoom(roomId)
     {
            const response = await fetch(Settings.baseApiUrl+'rooms/'+roomId+'/sensors');
            const data = await response.json();
            return data;
     };
    }