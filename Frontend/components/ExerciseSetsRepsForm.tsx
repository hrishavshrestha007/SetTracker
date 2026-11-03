"use client";

import { useState } from "react";
import { saveExerciseSetsReps } from "@/modules/exercise/actions";

interface ExerciseSet {
  setNumber: number;
  reps: number;
  weight: number | null;
  previousWeight: number | null;
  isCompleted: boolean;
}

interface ExerciseSetsRepsFormProps {
  exerciseId: number;
  initialSets: number | null;
  initialReps: number | null;
  initialWeight: number | null;
  isLoggedIn: boolean;
}

function createSet(
  setNumber: number,
  reps: number,
  weight: number | null,
): ExerciseSet {
  return {
    setNumber,
    reps,
    weight,
    previousWeight: null,
    isCompleted: false,
  };
}

export default function ExerciseSetsRepsForm({
  exerciseId,
  initialSets,
  initialReps,
  initialWeight,
  isLoggedIn,
}: ExerciseSetsRepsFormProps) {
  const startingSetCount = Math.max(1, initialSets ?? 1);
  const [exerciseSets, setExerciseSets] = useState<ExerciseSet[]>(
    Array.from({ length: startingSetCount }, (_, index) =>
      createSet(index + 1, initialReps ?? 10, initialWeight),
    ),
  );
  const [isSaving, setIsSaving] = useState(false);
  const [message, setMessage] = useState<string | null>(null);

  function updateSet(
    index: number,
    field: "reps" | "weight" | "isCompleted",
    value: number | null | boolean,
  ) {
    setExerciseSets((currentSets) =>
      currentSets.map((set, setIndex) =>
        setIndex === index ? { ...set, [field]: value } : set,
      ),
    );
  }

  function addSet() {
    setExerciseSets((currentSets) => [
      ...currentSets,
      createSet(currentSets.length + 1, 10, null),
    ]);
  }

  function removeSet(index: number) {
    setExerciseSets((currentSets) =>
      currentSets
        .filter((_, setIndex) => setIndex !== index)
        .map((set, setIndex) => ({ ...set, setNumber: setIndex + 1 })),
    );
  }

  async function handleSave() {
    if (!isLoggedIn) {
      setMessage("Please log in to save your sets.");
      return;
    }

    if (
      exerciseSets.some(
        (set) =>
          set.reps < 1 ||
          set.reps > 100 ||
          set.weight !== null && set.weight < 0,
      )
    ) {
      setMessage("Reps must be between 1 and 100. Weight cannot be negative.");
      return;
    }

    try {
      setIsSaving(true);
      setMessage(null);
      await saveExerciseSetsReps(exerciseId, exerciseSets);
      setMessage("Workout sets saved successfully.");
    } catch {
      setMessage("Failed to save. Please try again.");
    } finally {
      setIsSaving(false);
    }
  }

  return (
    <section className="rounded-2xl border border-white/10 bg-white/[0.03] p-5">
      <h2 className="text-xl font-semibold">Workout Setup</h2>
      <p className="mt-1 text-sm text-slate-300">
        Add a weight and reps value for each set.
      </p>

      <div className="mt-5 overflow-hidden rounded-xl border border-white/10">
        <div className="grid grid-cols-[48px_1fr_80px_80px_44px] gap-2 bg-slate-900 px-3 py-3 text-xs font-semibold uppercase tracking-wide text-slate-400">
          <span>Set</span>
          <span>Previous</span>
          <span>Kg</span>
          <span>Reps</span>
          <span />
        </div>

        <div className="space-y-2 p-3 text-slate-900">
          {exerciseSets.map((set, index) => (
            <div
              key={set.setNumber}
              className="grid grid-cols-[48px_1fr_80px_80px_44px] items-center gap-2"
            >
              <span className="text-center text-white font-semibold">{set.setNumber}</span>
              <span className="text-center text-sm text-white text-slate-600">
                {set.previousWeight ?? "-"}
              </span>
              <input
                type="number"
                min={0}
                value={set.weight ?? ""}
                onChange={(event) =>
                  updateSet(
                    index,
                    "weight",
                    event.target.value === "" ? null : Number(event.target.value),
                  )
                }
                className=" no-spinner w-full rounded-md border border-slate-300 bg-white px-2 py-1 text-center"
              />
              <input
                type="number"
                min={1}
                max={100}
                value={set.reps}
                onChange={(event) =>
                  updateSet(index, "reps", Number(event.target.value))
                }
                className=" no-spinner w-full rounded-md border border-slate-300 bg-white px-2 py-1 text-center"
              />
              <button
                type="button"
                onClick={() =>
                  updateSet(index, "isCompleted", !set.isCompleted)
                }
                className="text-xl"
                aria-label={`Mark set ${set.setNumber} complete`}
              >
                {set.isCompleted ? "✓" : "○"}
              </button>
            </div>
          ))}
        </div>
      </div>

      <button
        type="button"
        onClick={addSet}
        className="mt-3 w-full rounded-lg bg-slate-100 px-4 py-2 font-medium text-slate-800 transition hover:bg-white"
      >
        + Add Set
      </button>

      {exerciseSets.length > 1 ? (
        <button
          type="button"
          onClick={() => removeSet(exerciseSets.length - 1)}
          className="mt-2 w-full text-sm text-rose-300"
        >
          Remove last set
        </button>
      ) : null}

      <button
        type="button"
        onClick={handleSave}
        disabled={isSaving}
        className="mt-6 w-full rounded-lg bg-sky-500 px-4 py-2 font-semibold text-slate-950 transition hover:bg-sky-400 disabled:cursor-not-allowed disabled:opacity-70"
      >
        {isSaving ? "Saving..." : "Save Workout"}
      </button>

      {message ? (
        <p className="mt-3 text-sm text-amber-300">{message}</p>
      ) : null}
    </section>
  );
}
