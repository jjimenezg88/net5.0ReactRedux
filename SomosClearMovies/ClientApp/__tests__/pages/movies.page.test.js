import React from 'react';
import { shallow, mount } from 'enzyme';
import toJson from 'enzyme-to-json';
import { Provider } from "react-redux";
import configureStore from 'redux-mock-store'; // Smart components
import { act } from 'react-dom/test-utils';
import { Table, Container, Row, Col } from 'reactstrap';

import MoviesPage from '../../src/pages/movies/movies.page';
import FilterComponent from '../../src/components/filter.component';

const mockStore = configureStore();

const initialState = {
    movies: {
        movies: [
            {
                title: 'Movie 1',
                genere: 'Action',
                actors: ['Actor 1', 'Actor 2', 'Actor 3']
            },
            {
                title: 'Movie 2',
                genere: 'Action',
                actors: ['Actor 1', 'Actor 2', 'Actor 3']
            }
        ]
    }
};

const store = mockStore(initialState);

describe('<MoviesPage/>', () => {
    let wrapper;
    let mountedComponent;
    beforeEach(() => {
        wrapper = shallow(
            <Provider store={store}>
                <MoviesPage />
            </Provider>
        );
        act(() => {
            mountedComponent = mount(
                <Provider store={store}>
                    <MoviesPage />
                </Provider>
            );
        });
    });

    test('render the component', () => {
        const page = wrapper.dive();

        expect(toJson(page)).toMatchSnapshot();
    });

    test('should render Container', () => {
        const container = mountedComponent.find(Container);
        expect(container).toHaveLength(1);
    });

    test('should render Row', () => {
        const container = mountedComponent.find(Container);
        expect(container).toHaveLength(1);

        const row = container.find(Row);
        expect(row).toHaveLength(3);
    });

    test('should render Col', () => {
        const container = mountedComponent.find(Container);
        expect(container).toHaveLength(1);

        const col = container.find(Col);
        expect(col).toHaveLength(5);
    });

    test('should render FilterComponent', () => {
        const container = mountedComponent.find(Container);
        expect(container).toHaveLength(1);

        const filterComponent = container.find(FilterComponent);
        expect(filterComponent).toHaveLength(1);
    });

    test('should render Table', () => {
        const container = mountedComponent.find(Container);
        expect(container).toHaveLength(1);

        const table = container.find(Table);
        expect(table).toHaveLength(1);
    });

    test('should render thead', () => {
        const container = mountedComponent.find(Container);
        expect(container).toHaveLength(1);

        const thead = container.find('thead');
        expect(thead).toHaveLength(1);
    });

    test('should render tbody', () => {
        const container = mountedComponent.find(Container);
        expect(container).toHaveLength(1);

        const tbody = container.find('tbody');
        expect(tbody).toHaveLength(1);
    });

    test('should render tr', () => {
        const container = mountedComponent.find(Container);
        expect(container).toHaveLength(1);

        const tbody = container.find('tbody');
        expect(tbody).toHaveLength(1);

        const tr = tbody.find('tr');
        expect(tr).toHaveLength(2);
    });

    test('should render td', () => {
        const container = mountedComponent.find(Container);
        expect(container).toHaveLength(1);

        const tbody = container.find('tbody');
        expect(tbody).toHaveLength(1);

        const tr = tbody.find('tr');
        expect(tr).toHaveLength(2);

        const td = tr.at(0).find('td');
        expect(td).toHaveLength(3);

        expect(td.at(0).text()).toEqual('Movie 1');
        expect(td.at(1).text()).toEqual('Action');
        expect(td.at(2).text()).toEqual('Actor 1, Actor 2, Actor 3');
    });
});