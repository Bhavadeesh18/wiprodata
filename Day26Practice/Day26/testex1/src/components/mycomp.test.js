import React from 'react';
import { render, screen } from '@testing-library/react';
import MyComponent from './mycomp';

describe('MyComponent', () => {
    test('renders Hello, World! message', () => {
        render(<MyComponent />);
        
        const messageElement = screen.getByText('Hello, World!');
        expect(messageElement).toBeInTheDocument();
    });

    test("renders an h1 element", () => {
    render(<MyComponent />);
    const headingElement = screen.getByRole("heading", { level: 1 });
    expect(headingElement).toHaveTextContent("Hello, World!");
    });
});