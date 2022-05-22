class EditSchedule {

    baseUrl = '';
    token = ''
    
    maskapaiLookup = null;
    pesawatLookup = null;
    airportLookup = null;

    form = $('#formEditSchedule')

    formMode = 'create';
    title = $('#titleEditSchedule');

    btnFindMaskapai = $('#btnFindMaskapai');
    btnFindPesawat = $('#btnFindPesawat');
    btnFindAirportAsal = $('#btnFindAirportAsal')
    btnFindAirportTujuan = $('#btnFindAirportTujuan')

    kodeMaskapai = $('input[name=KodeMaskapai]');
    kodePenerbangan = $('input[name=KodePenerbangan]');
    kodeAirportAsal = $('input[name=KodeAirportAsal]')
    kodeAirportTujuan = $('input[name=KodeAirportTujuan]')

    tglKeberangkatan = $('input[name=TglKeberangkatan]')
    jamKeberangkatan = $('input[name=JamKeberangkatan]')

    tglKedatangan = $('input[name=TglKedatangan]')
    jamKedatangan = $('input[name=JamKedatangan]')

    batasBagasi = $('input[name=BatasBagasi]')
    batasBagasiKabin = $('input[name=BatasBagasiKabin]')

    hargaTiket = $('input[name=HargaTiket]')
    hargaTiketLabel = $('#HargaTiketLabel')

    btnSimpanJadwal = $('#btnSimpanJadwal')

    kodeMaskapaiErr = $('#KodeMaskapaiErr')
    kodePenerbanganErr = $('#KodePenerbanganErr')
    kodeAirportAsalErr = $('#KodeAirportAsalErr')
    kodeAirportTujuanErr = $('#KodeAirportTujuanErr')

    tglKeberangkatanErr = $('#TglKeberangkatanErr')
    jamKeberangkatanErr = $('#JamKeberangkatanErr')

    tglKedatanganErr = $('#TglKedatanganErr')
    jamKedatanganErr = $('#JamKedatanganErr')

    batasBagasiErr = $('#BatasBagasiErr')
    batasBagasiKabinErr = $('#BatasBagasiKabinErr')

    hargaTiketErr = $('#HargaTikeErr')


    fields = [
        {
            field: 'kodeMaskapai',
            err: 'kodeMaskapaiErr',
            validation: {
                type: 'required', msg: 'Kode Maskapai harus diisi'
            }
        },
        {
            field: 'kodePenerbangan',
            err: 'kodePenerbanganErr',
            validation: {
                type: 'required', msg: 'Kode Penerbangan harus diisi'
            }
        },
        {
            field: 'kodeAirportAsal',
            err: 'kodeAirportAsalErr',
            validation: {
                type: 'required', msg: 'Kode Airport Asal harus diisi'
            }
        },
        {
            field: 'kodeAirportTujuan',
            err: 'kodeAirportTujuanErr',
            validation: {
                type: 'required', msg: 'Kode Airport Tujuan harus diisi'
            }
        },
        {
            field: 'tglKeberangkatan',
            err: 'tglKeberangkatanErr',
            validation: {
                type: 'required', msg: 'Tgl.Keberangkatan harus diisi'
            }
        },
        {
            field: 'jamKeberangkatan',
            err: 'jamKeberangkatanErr',
            validation: {
                type: 'required', msg: 'Jam.Keberangkatan harus diisi'
            }
        },
        {
            field: 'tglKedatangan',
            err: 'tglKedatanganErr',
            validation: {
                type: 'required', msg: 'Tgl.Kedatangan harus diisi'
            }
        },
        {
            field: 'jamKedatangan',
            err: 'jamKedatanganErr',
            validation: {
                type: 'required', msg: 'Jam.Kedatangan harus diisi'
            }
        },
        {
            field: 'batasBagasi',
            err: 'batasBagasiErr',
            validation: {
                type: 'lte', msg: 'Batas Bagasi harus lebih besar atau sama dengan nol',
                val: 0,
            }
        },
        {
            field: 'batasBagasiKabin',
            err: 'batasBagasiKabinErr',
            validation: {
                type: 'lte', msg: 'Batas Bagasi Kabin harus lebih besar atau sama dengan nol',
                val: 0,
            }
        },
        {
            field: 'hargaTiket',
            err: 'hargaTiketErr',
            validation: {
                type: 'lte', msg: 'Harga Tiket harus lebih besar atau sama dengan nol',
                val: 0,
            }
        }
    ]

    

    constructor(baseUrl, token) {

        this.baseUrl = baseUrl;
        this.token = token;
        
        this.maskapaiLookup = new MaskapaiLookup(baseUrl, token);
        this.pesawatLookup = new PesawatLookup(baseUrl, token);
        this.airportLookup = new AirportLookup(baseUrl, token);

        var that = this;

        this.btnFindMaskapai.click(function () {
            that.maskapaiLookup.findMaskapaiList(function (kodeMaskapai) {
                that.kodeMaskapai.val(kodeMaskapai);
            })
        })

        this.btnFindPesawat.click(function () {
            that.pesawatLookup.findPesawatList(function (kodePenerbangan) {
                that.kodePenerbangan.val(kodePenerbangan);
            })
        })

        this.btnFindAirportAsal.click(function () {
            that.airportLookup.findAirportList(function (kodeAirport) {
                that.kodeAirportAsal.val(kodeAirport)
            })
        })

        this.btnFindAirportTujuan.click(function () {
            that.airportLookup.findAirportList(function (kodeAirport) {
                if (that.kodeAirportAsal.val() === kodeAirport) {
                    MessageBox.show('Airport Tujuan tidak boleh sama dengan Airport Asal')
                } else {
                    that.kodeAirportTujuan.val(kodeAirport)
                }
            })
        })

        this.hargaTiket.keyup(function () {
            const _hargaTiket = Number($(this).val())
            that.hargaTiketLabel.html('Harga Tiket (' + Format.thousand(_hargaTiket) + ')')
        })


        
        this.btnSimpanJadwal.click(function (e) {

            
            e.preventDefault()
            if (that.validateInput()) {

                const pData = {
                    KodeMaskapai: that.kodeMaskapai.val(),
                    kodePenerbangan: that.kodePenerbangan.val(),
                    kodeAirportAsal: that.kodeAirportAsal.val(),
                    kodeAirportTujuan: that.kodeAirportTujuan.val(),
                    strTglKeberangkatan: that.tglKeberangkatan.val() + ' ' + that.jamKeberangkatan.val(),
                    strTglKedatangan: that.tglKedatangan.val() + ' ' + that.jamKedatangan.val(),
                    batasBagasi: Number(that.batasBagasi.val()),
                    batasBagasiKabin: Number(that.batasBagasiKabin.val()),
                    hargaTiket: Number(that.hargaTiket.val()),
                }

                fetch('/api/schedule/insert', {
                    method: 'POST',
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type' : 'application/json',
                        't' : that.token,
                    },
                    body: JSON.stringify(pData)
                })
                    .then(response => response.json())
                    .then(() => {
                        debugger
                        var msg = 'Jadwal Berhasil ditambah';
                        var url = '/Admin/Schedule/Index?t=' + encodeURIComponent(that.token) + '&Message=' + msg;
                        window.location.replace(url);
                        
                    })
                    .catch(error => {
                        console.error('Unable to add item.', error)
                        MessageBox.show(error)
                    });

            } else {
                alert('Ga OK')
            }
        })


        this.fields.forEach(f => {
            this[f.field].keyup(function () {
                if (f.validation) {
                    if (f.validation.type === 'required') {
                        that.required(that[f.field], that[f.err], f.validation.msg)

                    } else if (f.validation.type === 'lte') {
                        that.lte(that[f.field], that[f.err], f.validation.msg, f.validation.val)

                    }
                }

            })
            this[f.field].change(function () {
                if (f.validation) {
                    if (f.validation.type === 'required') {
                        that.required(that[f.field], that[f.err], f.validation.msg)

                    } else if (f.validation.type === 'lte') {
                        that.lte(that[f.field], that[f.err], f.validation.msg, f.validation.val)

                    }
                }

            })
        })
    }

    lte(f, err, msg, val) {
        if (Number(f.val()) <= Number(val)) {
            err.text(msg)
            return false
        } else {
            err.text('')
            return true
        }
    }

    required(f, err, msg) {
        if (!f.val()) {
            err.text(msg)
            return false
        } else {
            err.text('')
            return true
        }
    }

    validateInput() {
        let valid = true
        var that = this
        this.fields.forEach((f) => {

            /*if(f.field === 'jamKeberangkatan') {
                debugger
                console.log(that.jamKeberangkatan.val())
            }
            if(f.field === 'jamKedatangan') {
                debugger
                console.log(that.jamKedatangan.val())
            }*/

            if (f.validation) {
                if (f.validation.type === 'required') {
                    valid = that.required(that[f.field], that[f.err], f.validation.msg)

                } else if (f.validation.type === 'lte') {
                    valid = that.lte(that[f.field], that[f.err], f.validation.msg, f.validation.val)

                }
            }
        })
        return valid;


    }


}
