import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { FormGroup, Label, Input, Row, Col, Alert } from 'reactstrap';
import { getMoviesStartAsync } from './../redux/movie';

const FilterComponent = ({ getMovies }) => {
    const [movieFilter, setMovieFilter] = useState({ title: '', genre: '', actorName: '' });
    const { title, genre, actorName } = movieFilter

    useEffect(() => {
        getMovies(title, genre, actorName);
    }, [title, genre, actorName, getMovies]);

    const handleChange = event => {
        const { value, name } = event.target;
        setMovieFilter({ ...movieFilter, [name]: value });
    };

    return (
        <>
            <Alert id="alert-info" color="primary">
                To filter just type on any input <b>(Title, Genre, and/or Actor Name)</b>!
            </Alert>
            <Row>
                <Col md="4">
                    <FormGroup>
                        <Label for="movie-title">Title</Label>
                        <Input type="text" name="title" id="movie-title" placeholder="Enter a title"
                            value={title} onChange={handleChange} />
                    </FormGroup>
                </Col>
                <Col md="4">
                    <FormGroup>
                        <Label for="movie-genre">Genre</Label>
                        <Input type="text" name="genre" id="movie-genre" placeholder="Enter a genre"
                            value={genre} onChange={handleChange} />
                    </FormGroup>
                </Col>
                <Col md="4">
                    <FormGroup>
                        <Label for="movie-actor-name">Actor Name</Label>
                        <Input type="text" name="actorName" id="movie-actor-name" placeholder="Enter an actor name"
                            value={actorName} onChange={handleChange} />
                    </FormGroup>
                </Col>
            </Row>
        </>
    );
};

const mapDispatchToProps = dispatch => ({
    getMovies: (title, genere, autorName) => getMoviesStartAsync(title, genere, autorName)(dispatch)
});

export default connect(null, mapDispatchToProps)(FilterComponent);