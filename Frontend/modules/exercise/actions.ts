'use server';

import { cookies } from "next/headers";
import { API_URL } from "@/libs/constants";

export async function saveExerciseSetsReps(
	exerciseId: number,
	sets: Array<{
		setNumber: number;
		reps: number;
		weight: number | null;
		previousWeight: number | null;
		isCompleted: boolean;
	}>,
) {
	const token = (await cookies()).get("token")?.value;

	if (!token) {
		throw new Error("Please log in to save your sets and reps.");
	}

	const response = await fetch(`${API_URL}/api/user-exercises/${exerciseId}`, {
		method: "PUT",
		headers: {
			"Content-Type": "application/json",
			Authorization: `Bearer ${token}`,
		},
		body: JSON.stringify({
			exerciseId,
			sets,
		}),
	});

	if (!response.ok) {
		const errorMessage = await response.text();
		throw new Error(
			`Failed to save exercise with id ${exerciseId}: ${response.status} ${errorMessage}`,
		);
	}
}

export async function removeExerciseFromWorkout(exerciseId: number) {
	const token = (await cookies()).get("token")?.value;

	if (!token) {
		throw new Error("Please log in to remove this exercise.");
	}

	const response = await fetch(`${API_URL}/api/user-exercises/${exerciseId}`, {
		method: "DELETE",
		headers: {
			Authorization: `Bearer ${token}`,
		},
	});

	if (!response.ok) {
		throw new Error(`Failed to remove exercise with id ${exerciseId}: ${response.status}`);
	}
}
