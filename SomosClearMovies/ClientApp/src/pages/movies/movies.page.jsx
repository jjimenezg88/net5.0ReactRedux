import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import { Table, Container, Row, Col } from 'reactstrap';
import { selectMovies } from '../../redux/movie';
import { getMoviesStartAsync } from '../../redux/movie';

import FilterComponent from '../../components/filter.component';

const MoviePage = ({ movies, getMovies }) => {
    useEffect(() => {
        getMovies();
    }, [getMovies]);

    return (
        <Container>
            <Row>
                <Col md="12">
                    <FilterComponent />
                </Col>
            </Row>
            <Row>
                <Col md="12">
                    <Table className='table table-striped' aria-labelledby="tabelLabel">
                        <thead>
                            <tr>
                                <th>Title</th>
                                <th>Genre</th>
                                <th>Actors</th>
                            </tr>
                        </thead>
                        <tbody>
                            {movies.map((movie, index) =>
                                <tr key={index}>
                                    <td>{movie.title}</td>
                                    <td>{movie.genre}</td>
                                    <td>{movie.actors}</td>
                                </tr>
                            )}
                        </tbody>
                    </Table>
                </Col>
            </Row>
        </Container>
    );
};

const mapStateToProps = (state) => ({
    movies: selectMovies(state)
});

const mapDispatchToProps = dispatch => ({
    getMovies: (title, genere, autorName) => getMoviesStartAsync(title, genere, autorName)(dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(MoviePage);