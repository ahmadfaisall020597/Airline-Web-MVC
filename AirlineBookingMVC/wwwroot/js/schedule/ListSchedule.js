class ListSchedule {

    baseUrl = '';
    token = ''

    constructor(baseUrl, token) {

        this.baseUrl = baseUrl;
        this.token = token;

    }

    getListData() {
        fetch(baseUrl + '/api/schedule/list', {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                't': this.token,
            }
        })
            .then(response => response.json())
            .then(data => {

                const body = $('#bodySchedules')
                body.empty();
                if(data && data.length>0) {
                    for (let i = 0; i < data.length; i++) {
                        let d = data[i]

                        let str = '<tr>';

                        str += '<td><button class="btn btn-primary" ' +
                            'asp-area="Admin" ' +
                            'asp-action="Edit"' +
                            'asp-controller="Schedule"' +
                            '>Edit</button></td>'
                        str += '<td>' + d.scheduleID + '</td>'
                        str += '<td>' + d.kodeMaskapai + '</td>'
                        str += '<td>' + d.maskapai.namaMaskapai + '</td>'

                        str += '<td>' + d.kodePenerbangan + '</td>'
                        str += '<td>' + d.kodeAirportAsal + '</td>'
                        str += '<td>' + d.airportAsal.namaAirport + '</td>'
                        str += '<td>' + d.kodeAirportTujuan + '</td>'
                        str += '<td>' + d.airportTujuan.namaAirport + '</td>'
                        str += '<td>' + d.tglKeberangkatan + '</td>'
                        str += '<td>' + d.tglKedatangan + '</td>'
                        str += '<td>' + d.batasBagasi + '</td>'
                        str += '<td>' + d.batasBagasiKabin + '</td>'
                        str += '<td>' + d.hargaTiket + '</td>'
                        str += '<td>' + d.createdAt + '</td>'
                        str += '<td>' + d.createdBy + '</td>'
                        str += '<td>' + d.updatedAt + '</td>'
                        str += '<td>' + d.updatedBy + '</td>'

                        str += '</tr>'
                        body.append(str)
                    }
                } else {
                    let str = '<tr><td colspan="18">Belum Ada Data</td></tr>';
                    body.append(str)
                }
                


            });
    }
}  