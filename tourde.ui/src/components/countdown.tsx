import { DateTime, Duration } from "luxon";
import { useEffect, useState } from "react";

const Countdown = () => {
    const startDate: string = process.env.REACT_APP_RACE_START!;
    const initialDuration: Duration = calculateTimeUntilStart(startDate);
    const [currentDuration, setDuration] = useState(initialDuration);

    useEffect(() => {
        const interval = setInterval(() => {
            const duration = calculateTimeUntilStart(startDate);
            setDuration(duration);
        }, 1000);
        return () => clearInterval(interval);
    });

    return (
        <div className="countdown">
            <p>The ride starts in:</p>
            <div id='day'>
                <div className="countdownValue">{currentDuration.days}</div>
                <span>days</span>
            </div>
            <div id='hours'>
                <div className="countdownValue">{currentDuration.hours}</div>
                <span>hours</span>
            </div>
            <div id='minutes'>
                <div className="countdownValue">{currentDuration.minutes}</div>
                <span>minutes</span>
            </div>
            <div id='seconds'>
                <div className="countdownValue">{currentDuration.seconds.toFixed(0)}</div>
                <span>seconds</span>
            </div>
        </div>
    );
}

/**
 * Determines time until race start.
 * @param startDate 
 * @returns 
 */
const calculateTimeUntilStart = (startDate: string): Duration => {
    let startTime: DateTime = DateTime.fromJSDate(new Date(startDate), {zone: process.env.REACT_APP_TIMEZONE});
    return startTime.diffNow(['day', 'hour', 'minute', 'second']);
}

export default Countdown;