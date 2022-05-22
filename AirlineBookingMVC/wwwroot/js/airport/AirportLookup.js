class AirportLookup {

    lookupDialog = $('#lkpAirportDialog')
    
    baseUrl = '';
    token = '';
    constructor(baseUrl, token) {
        this.baseUrl = baseUrl;
        this.token = token
    }

    findAirportList(onSelected) {

        const that = this;
        fetch(this.baseUrl + '/api/airport/list', {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                't': this.token,
            }
        })
            .then(response => response.json())
            .then(data => {

                const body = $('#bodyAirportLookup')
                body.empty();
               
                for (let i=0;i<data.length;i++) {
                    let d = data[i]
                    let str= '<tr>';
                    str += '<td><button type="button" class="btn btn-primary btn-select-airport" data-id="' + d.kodeAirport + '">Pilih</button></td>'                    
                    str += '<td>' + d.kodeAirport +  '</td>'
                    str += '<td>' + d.namaAirport + '</td>'
                    str += '<td>' + d.kota + '</td>'
                    str += '<td>' + d.propinsi + '</td>'
                    str += '</tr>'
                    body.append(str)
                }
                
                

                $('.btn-select-airport').click(function (){
                    onSelected($(this).data('id'))
                    that.lookupDialog.modal('hide')

                });

                that.lookupDialog.modal('show');

            });
    }
}