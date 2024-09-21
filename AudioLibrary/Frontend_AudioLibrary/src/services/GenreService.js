import { HttpService } from "./HttpService"


async function get(){
    return await HttpService.get('/Genre')
    .then((odgovor)=>{
        console.log(odgovor.data);
        //console.table(odgovor.data);
        return odgovor.data;
    })
    .catch((e)=>{console.error(e)})
}

async function getById(id){
    return await HttpService.get('/Genre/' + id)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Genre does not exist!'}
    })
}

async function obrisi(id) {
    return await HttpService.delete('/Genre/' + id)
    .then((odgovor)=>{
        //console.log(odgovor);
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        //console.log(e);
        return {greska: true, poruka: 'This genre cannot be deleted'}
    })
}


async function dodaj(genre) {
    return await HttpService.post('/Genre',genre)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        return {greska: true, poruka: 'Genre cannot be added!'}
    })
}


async function promjena(id,genre) {
    return await HttpService.put('/Genre/' + id,genre)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Genre cannot be changed!'}
    })
}


export default{
    get,
    getById,
    obrisi,
    dodaj,
    promjena
}