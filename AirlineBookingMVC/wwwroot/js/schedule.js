const baseUrl = 'http://localhost:5250'
export class ListSchedule {    
    constructor() {}    
    getListData() {        
        fetch(baseUrl + '/api/schedule/list')
            .then(response => response.json())
            .then(data => {
                    console.log(data)
            });
        
    }
    
}