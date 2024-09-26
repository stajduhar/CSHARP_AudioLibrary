import { Button, Container, Table } from "react-bootstrap";
import GenreService from "../../services/GenreService";
//import { useEffect } from "react";
//import GenreService from "../../services/GenreService";
import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";


export default function GenresOverview(){

    const[genres,setGenres] = useState();
    const navigate = useNavigate();
    
    async function getGenres() {

        // zaustavi kod u Chrome consoli i tamo se može raditi debug
        //debugger;

        await GenreService.get()
        .then((odgovor)=>{
            //console.log(odgovor);
            setGenres(odgovor);
        })
        .catch((e)=>{console.log(e)});
    }

    


    useEffect(()=>{
        getGenres();
    },[]);

    //useEffect(()=>{
        //getGenres();
    //},[]);

    async function obrisiAsync(id) {
        const odgovor = await GenreService.obrisi(id);
        //console.log(odgovor);
        if(odgovor.greska){
            alert(odgovor.poruka);
            return;
        }
        getGenres();
    }

    function obrisi(id){
        obrisiAsync(id);
    }

    return(
        <Container>
            <Link to={RoutesNames.GENRE_NEW}>Add new genre</Link>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>id</th>
                        <th>name of genre</th>
                        <th>action</th>
                    </tr>
                </thead>
                <tbody>
                    {genres && genres.map((genre,index)=>(
                        <tr key={index}>
                            <td>{genre.id}</td>
                            <td>{genre.name_of_genre}</td>
                            <td>
                                <Button
                                variant="primary"
                                onClick={()=>navigate(`/genres/${genre.id}`)}>
                                    Change
                                </Button>
                                &nbsp;&nbsp;&nbsp;
                                <Button
                                variant="danger"
                                onClick={()=>obrisi(genre.id)}>
                                    Delete
                                </Button>


                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    )

}