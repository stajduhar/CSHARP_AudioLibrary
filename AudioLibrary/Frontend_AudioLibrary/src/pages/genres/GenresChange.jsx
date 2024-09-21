import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { RoutesNames } from "../../constants";
import { Link, useNavigate, useParams } from "react-router-dom";
import GenreService from "../../services/GenreService";
import { useEffect, useState } from "react";


export default function GenresChange(){ // ovdje je potencijalno problem jer mi nije ponudilo GenresAdd ovdje se radilo oko 33 minute u videu

    const navigate = useNavigate();
    const routeParams = useParams();
    const [genre,setGenre] = useState({});



        async function getGenre(){
            const odgovor = await GenreService.getById(routeParams.id);
            if(odgovor.greska){
                alert(odgovor.poruka);
                return;
            }
            setGenre(odgovor.poruka);
        }

        useEffect(()=>{
            getGenre();
        },[]);


        async function promjena(genre){
            //console.log(smjer);
            //console.log(JSON.stringify(smjer));
            const odgovor = await GenreService.promjena(routeParams.id,genre);
            if(odgovor.greska){
                alert(odgovor.poruka);
                return;
            }
            navigate(RoutesNames.GENRES_OVERVIEW);
        }

    function obradiSubmit(e){ // e predstavlja event
        e.preventDefault();

        const podaci = new FormData(e.target);

        promjena({
            name_of_genre: podaci.get('name_of_genre') // 'naziv' je došao iz atributa name od From.Control
        });
        
    }

    return(
        <Container>
            Change genre
            
            <Form onSubmit={obradiSubmit}>


                <Form.Group controlId="name_of_genre">
                    <Form.Label>Name</Form.Label>
                    <Form.Control type="text" name="name_of_genre" required 
                    defaultValue={genre.name_of_genre} />
                </Form.Group>

                <hr />
            <Row>
                <Col xs={6} sm={6} md={3} lg={6} xl={6} xxl={6}>
                <Link to={RoutesNames.GENRES_OVERVIEW}
                className="btn btn-danger siroko">
                Abort
                </Link>
                </Col>
                <Col xs={6} sm={6} md={9} lg={6} xl={6} xxl={6}>
                <Button variant="primary" type="submit" className="siroko">
                    Change genre
                </Button>
                </Col>
            </Row>
            </Form>
        </Container>
    )
}