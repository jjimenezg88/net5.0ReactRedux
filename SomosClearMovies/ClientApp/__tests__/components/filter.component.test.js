import React from 'react';
import { shallow, mount } from 'enzyme';
import toJson from 'enzyme-to-json';
import { Provider } from "react-redux";
import configureStore from 'redux-mock-store'; // Smart components
import { act } from 'react-dom/test-utils';
import { FormGroup, Label, Input, Row, Col, Alert } from 'reactstrap';

import FilterComponent from '../../src/components/filter.component';

const mockStore = configureStore();

const initialState = {};

const store = mockStore(initialState);

describe('<FilterComponent />', () => {
    let wrapper;
    let mountedComponent;
    beforeEach(() => {
        wrapper = shallow(
            <Provider store={store}>
                <FilterComponent />
            </Provider>
        );
        act(() => {
            mountedComponent = mount(
                <Provider store={store}>
                    <FilterComponent />
                </Provider>
            );
        });
    });

    test('render the component', () => {
        const component = wrapper.dive();

        expect(toJson(component)).toMatchSnapshot();
    });

    test('should render alert', () => {
        const alert = mountedComponent.find(Alert);
        expect(alert).toHaveLength(1);
        expect(alert.text()).toEqual('To filter just type on any input (Title, Genre, and/or Actor Name)!');
    });

    test('should render Row', () => {
        const row = mountedComponent.find(Row);
        expect(row).toHaveLength(1);
    });

    test('should render Col', () => {
        const row = mountedComponent.find(Row);
        expect(row).toHaveLength(1);

        const col = row.find(Col);
        expect(col).toHaveLength(3);
    });

    test('should render FormGroup', () => {
        const row = mountedComponent.find(Row);
        expect(row).toHaveLength(1);

        const col = row.find(Col);
        expect(col).toHaveLength(3);

        const formGroup = row.find(FormGroup);
        expect(formGroup).toHaveLength(3);
    });

    test('should render Label', () => {
        const row = mountedComponent.find(Row);
        expect(row).toHaveLength(1);

        const col = row.find(Col);
        expect(col).toHaveLength(3);

        const formGroup = row.find(FormGroup);
        expect(formGroup).toHaveLength(3);

        const label = formGroup.find(Label);
        expect(label).toHaveLength(3);
    });

    test('should render Input', () => {
        const row = mountedComponent.find(Row);
        expect(row).toHaveLength(1);

        const col = row.find(Col);
        expect(col).toHaveLength(3);

        const formGroup = row.find(FormGroup);
        expect(formGroup).toHaveLength(3);

        const label = formGroup.find(Label);
        expect(label).toHaveLength(3);

        const input = formGroup.find(Input);
        expect(input).toHaveLength(3);
    });

    test('should create an entry in component state', () => {
        const input = mountedComponent.find('input[name="title"]')
        act(() => {
            input.props().onChange({ target: { name: 'title', value: 'test' } });
            expect(store.getActions()).toMatchSnapshot();
        });
    });
});