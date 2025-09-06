import React from 'react';
import { render, screen } from '@testing-library/react';
import Greeting from './greeting';

describe('Greeting Component', () => {
    test("renders good morning message", () => {
        render(<Greeting />);
        
        const messageElement = screen.getByText("Good Morning to All...");
        expect(screen.queryByText("Good Afternoon to All...")).not.toBeInTheDocument();
        expect(screen.queryByText("Good Evening to All...")).not.toBeInTheDocument();
        expect(screen.queryByText("Good Afternoon to All...")).not.toBeInTheDocument();
    
        expect(messageElement).toBeInTheDocument();
    });
});